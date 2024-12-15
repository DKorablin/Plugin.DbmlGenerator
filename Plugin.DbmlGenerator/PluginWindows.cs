using System;
using System.Collections.Generic;
using System.Diagnostics;
using SAL.Flatbed;
using SAL.Windows;

namespace Plugin.DbmlGenerator
{
	public class PluginWindows : IPlugin, IPluginSettings<PluginSettings>
	{
		private TraceSource _trace;

		private IMenuItem _menuPlugin;

		private PluginSettings _settings;

		private Dictionary<String, DockState> _documentTypes;

		internal TraceSource Trace
		{
			get { return this._trace ?? (this._trace = PluginWindows.CreateTraceSource<PluginWindows>()); }
		}

		internal IHostWindows HostWindows { get; }

		Object IPluginSettings.Settings { get { return this.Settings; } }

		public PluginSettings Settings
		{
			get
			{
				if(this._settings == null)
				{
					this._settings = new PluginSettings(this);
					this.HostWindows.Plugins.Settings(this).LoadAssemblyParameters(this._settings);
				}
				return this._settings;
			}
		}

		internal event EventHandler<EventArgs> ConnectionListChanged;

		private Dictionary<String, DockState> DocumentTypes
		{
			get
			{
				if(this._documentTypes == null)
					this._documentTypes = new Dictionary<String, DockState>()
					{
						{ typeof(PanelGenerator).ToString(), DockState.DockBottom }
					};
				return this._documentTypes;
			}
		}

		public PluginWindows(IHostWindows hostWindows)
			=> this.HostWindows = hostWindows ?? throw new ArgumentNullException(nameof(hostWindows));

		public IWindow GetPluginControl(String typeName, KeyValuePair<String,Object>[] args)
			=> this.CreateWindow(typeName, true, args);

		public ConfigCtrl GetPluginOptionsControl()
			=> new ConfigCtrl(this);

		Boolean IPlugin.OnConnection(ConnectMode mode)
		{
			IMenuItem menuData = this.HostWindows.MainMenu.FindMenuItem("Data");
			if(menuData == null)
			{
				menuData = this.HostWindows.MainMenu.Create("Data");
				this.HostWindows.MainMenu.Items.Add(menuData);
			}

			IMenuItem menuPlugins = menuData.FindMenuItem("ORM");
			if(menuPlugins == null)
			{
				menuPlugins = menuData.Create("ORM");
				menuPlugins.Name = "Data.ORM";
				menuData.Items.Add(menuPlugins);
			}
			this._menuPlugin = menuPlugins.Create("DBML Generator");
			this._menuPlugin.Name = "Data.ORM.DbmlGenerator";
			this._menuPlugin.Click += new EventHandler(MenuPlugin_Click);
			menuPlugins.Items.Add(this._menuPlugin);
			return true;
		}

		Boolean IPlugin.OnDisconnection(DisconnectMode mode)
		{
			if(this._menuPlugin != null)
				this.HostWindows.MainMenu.Items.Remove(this._menuPlugin);
			return true;
		}

		internal void OnConnectionListChanged()
			=> this.ConnectionListChanged?.Invoke(this, EventArgs.Empty);

		private IWindow CreateWindow(String typeName, Boolean searchForOpened, params KeyValuePair<String,Object>[] args)
			=> this.DocumentTypes.TryGetValue(typeName, out DockState state)
				? this.HostWindows.Windows.CreateWindow(this, typeName, searchForOpened, state, args)
				: null;

		private void MenuPlugin_Click(Object sender, EventArgs e)
			=> _ = this.HostWindows.Windows.CreateWindow(this, typeof(PanelGenerator).ToString(), true, DockState.DockBottom, null);

		private static TraceSource CreateTraceSource<T>(String name = null) where T : IPlugin
		{
			TraceSource result = new TraceSource(typeof(T).Assembly.GetName().Name + name);
			result.Switch.Level = SourceLevels.All;
			result.Listeners.Remove("Default");
			result.Listeners.AddRange(System.Diagnostics.Trace.Listeners);
			return result;
		}
	}
}