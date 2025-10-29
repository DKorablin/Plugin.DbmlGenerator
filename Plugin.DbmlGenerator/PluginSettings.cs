using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace Plugin.DbmlGenerator
{
	public class PluginSettings : INotifyPropertyChanged
	{
		internal static class Properties
		{
			public const String Connections = "Connections";
			public const String LastConnection = "LastConnection";
			public const String LastSql = "LastSql";
			public const String SaveWithXsd = "SaveWithXsd";
			public const String AddComments = "AddComments";
			public const String Template = "Template";
		}

		private String _connections;
		private Int32 _lastConnection;
		private String _lastSql;
		private Boolean _saveWithXsd;
		private Boolean _addComments = true;
		private List<DbConnectionItem> _dbConnections;
		private String _template;
		private readonly PluginWindows _plugin;

		[Browsable(false)]
		public String Connections
		{
			get => this._connections;
			set => this.SetField(ref this._connections, value, Properties.Connections);
		}

		[Browsable(false)]
		public Int32 LastConnection
		{
			get => this._lastConnection;
			set => this.SetField(ref this._lastConnection, value, Properties.LastConnection);
		}

		[Browsable(false)]
		public String LastSql
		{
			get => this._lastSql;
			set => this.SetField(ref this._lastSql, value, Properties.LastSql);
		}

		[Category("XML")]
		[DefaultValue(false)]
		[DisplayName("Save with XSD")]
		[Description("Save dataset with XSD")]
		public Boolean SaveWithXsd
		{
			get => this._saveWithXsd;
			set => this.SetField(ref this._saveWithXsd, value, Properties.SaveWithXsd);
		}

		[DefaultValue(true)]
		[DisplayName("Add comments")]
		[Description("Add executing command as comment to result dataSet")]
		public Boolean AddComments
		{
			get => this._addComments;
			set => this.SetField(ref this._addComments, value, Properties.AddComments);
		}

		[DisplayName("SQL Template")]
		[Description("Specify template for")]
		[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		public String Template
		{
			get => this._template;
			set => this.SetField(ref this._template, value, Properties.Template);
		}

		public PluginSettings(PluginWindows plugin)
			=> this._plugin = plugin ?? throw new ArgumentNullException(nameof(plugin));

		public List<DbConnectionItem> GetConnections()
		{
			if(this._dbConnections == null)
				this._dbConnections = this.Connections == null
					? new List<DbConnectionItem>()
					: new List<DbConnectionItem>(Array.ConvertAll<String, DbConnectionItem>(this.Connections.Split(new Char[] { Constants.Settings.ConnectionsSeparator, }, StringSplitOptions.RemoveEmptyEntries), item => new DbConnectionItem(item)));

			return this._dbConnections;
		}

		private void SaveConnections(List<DbConnectionItem> connections)
		{
			this.Connections = String.Join(Constants.Settings.ConnectionsSeparator.ToString(), Array.ConvertAll<DbConnectionItem, String>(connections.ToArray(), item => item.ToString()));
			this._plugin.HostWindows.Plugins.Settings(this._plugin).SaveAssemblyParameters();
			this._dbConnections = connections;
			this._plugin.OnConnectionListChanged();//HINT: You can't use INotifyPropertyChanged here because _dbConnections is placed after the property.
		}

		public void SaveLastCommands(Int32 lastConnection, String lastSql)
		{
			if(lastConnection != this.LastConnection || lastSql != this.LastSql)
			{
				this.LastConnection = lastConnection;
				this.LastSql = lastSql;
				this._plugin.HostWindows.Plugins.Settings(this._plugin).SaveAssemblyParameters();
			}
		}

		public DbConnectionItem AddConnection(String name, String connectionString, String providerName)
		{
			if(String.IsNullOrEmpty(name))
				throw new ArgumentNullException(nameof(name));
			if(String.IsNullOrEmpty(connectionString))
				throw new ArgumentNullException(nameof(connectionString));
			if(String.IsNullOrEmpty(providerName))
				throw new ArgumentNullException(nameof(providerName));

			DbConnectionItem item = new DbConnectionItem()
			{
				Name = this.GetUniqueName(name, 0),
				ConnectionString = connectionString,
				ProviderName = providerName,
			};

			List<DbConnectionItem> items = this.GetConnections();
			items.Add(item);
			this.SaveConnections(items);
			return item;
		}

		/// <summary>Deleting a connection string by name</summary>
		/// <param name="name">Name of the connection string to the data source</param>
		/// <exception cref="ArgumentNullException">Item not found</exception>
		public void RemoveConnection(String name)
		{
			if(String.IsNullOrEmpty(name))
				throw new ArgumentNullException(nameof(name));

			List<DbConnectionItem> items = this.GetConnections();
			DbConnectionItem item = items.Find(search => search.Name == name)
				?? throw new ArgumentNullException($"Connection {name} not found");

			items.Remove(item);
			this.SaveConnections(items);
		}

		/// <summary>Rename the data source connection string name</summary>
		/// <param name="oldName">Old name</param>
		/// <param name="newName">New name</param>
		public void RenameConnection(String oldName, String newName)
		{
			if(String.IsNullOrEmpty(oldName))
				throw new ArgumentNullException(nameof(oldName));
			if(String.IsNullOrEmpty(newName))
				throw new ArgumentNullException(nameof(newName));

			List<DbConnectionItem> items = this.GetConnections();
			DbConnectionItem item = items.Find(search => search.Name == oldName)
				?? throw new ArgumentNullException($"Connection {oldName} not found");

			item.Name = this.GetUniqueName(newName, 0);
			this.SaveConnections(items);
		}

		/// <summary>Get a unique name for the data source connection string</summary>
		/// <param name="name">Name, which must be unique</param>
		/// <param name="index">Recursion index</param>
		/// <returns>Unique name of the data source</returns>
		private String GetUniqueName(String name, UInt32 index)
		{
			String indexName = index > 0
				? $"{name}[{index}]"
				: name;

			if(this.Connections != null)
				foreach(DbConnectionItem item in this.GetConnections())
					if(item.Name.Equals(indexName))
						return this.GetUniqueName(name, index + 1);
			return indexName;
		}

		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		private Boolean SetField<T>(ref T field, T value, String propertyName)
		{
			if(EqualityComparer<T>.Default.Equals(field, value))
				return false;

			field = value;
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			return true;
		}
		#endregion INotifyPropertyChanged
	}
}