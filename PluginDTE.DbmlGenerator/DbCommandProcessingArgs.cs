using System;
using AlphaOmega.Data;

namespace PluginDTE.DbmlGenerator
{
	public class DbCommandProcessingArgs : EventArgs
	{
		public enum ActionType
		{
			None = 0,
			/// <summary>Получить DBML</summary>
			Dbml = 1,
			/// <summary>Получить таблицу</summary>
			Grid = 2,
			/// <summary>Получить XML</summary>
			Xml = 3,
			/// <summary>Отформатировать по шаблону</summary>
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