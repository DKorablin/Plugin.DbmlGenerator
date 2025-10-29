using System;
using AlphaOmega.Data;

namespace Plugin.DbmlGenerator
{
	public class DbCommandProcessingArgs : EventArgs
	{
		public enum ActionType
		{
			None = 0,
			/// <summary>Get DBML</summary>
			Dbml = 1,
			/// <summary>Get Table</summary>
			Grid = 2,
			/// <summary>Get XML</summary>
			Xml = 3,
			/// <summary>Format with Template</summary>
			Template = 4,
		}

		public ActionType Type { get; }

		public String SqlCommand { get; }

		public ProcedureInfo? Procedure { get; }

		public Object Result { get; set; }

		public DbCommandProcessingArgs(ActionType type, String sqlCommand, ProcedureInfo? procedure)
		{
			this.Type = type;
			this.SqlCommand = sqlCommand;
			this.Procedure = procedure;
		}
	}
}