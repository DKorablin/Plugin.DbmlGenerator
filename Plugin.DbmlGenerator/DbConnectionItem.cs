using System;

namespace Plugin.DbmlGenerator
{
	[Serializable]
	public class DbConnectionItem
	{
		public String Name;

		public String ConnectionString;

		public String ProviderName;

		public DbConnectionItem() { }

		public DbConnectionItem(String saved)
		{
			_ = saved ?? throw new ArgumentNullException(nameof(saved));
			String[] parts = saved.Split(Constant.Settings.ConnectionParamsSeparator);
			if(parts.Length == 3)
			{
				this.Name = parts[0];
				this.ConnectionString = parts[1];
				this.ProviderName = parts[2];
			} else
				throw new InvalidCastException();
		}

		public override String ToString()
		{
			Char[] invalidChars = new Char[] { Constant.Settings.ConnectionParamsSeparator, Constant.Settings.ConnectionsSeparator, };
			if(this.Name.IndexOfAny(invalidChars) > -1
				|| this.ProviderName.IndexOfAny(invalidChars) > -1
				|| this.ConnectionString.IndexOfAny(invalidChars) > -1)
				throw new ArgumentException("Chars \\n & \\r invalid");

			return String.Join(Constant.Settings.ConnectionParamsSeparator.ToString(),
				new String[] { this.Name, this.ConnectionString, this.ProviderName, });
		}
	}
}