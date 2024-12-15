using System;

namespace PluginDTE.DbmlGenerator
{
	internal static class Constant
	{
		public static class Dbml
		{
			public static class Column
			{
				public const String TableStartTemplateArgs1 = "<ElementType Name=\"Element_{0}\">";
				public const String TableEndTemplate = "</ElementType>";
				public const String RowTemplateArgs4 = "\t<Column Name=\"{0}\" Type=\"{1}\" DbType=\"{2}\" CanBeNull=\"{3}\" />";
			}

			public static class Parameters
			{
				public const String FunctionStartArg1 = "<Function Name=\"{0}\">\r\n";
				public const String FunctionEnd = "</Function>";
				public const String ParameterArg4 = "\t<Parameter Name=\"{0}\" Type=\"{1}\" DbType=\"{2}\"{3} />\r\n";
			}
		}

		public static class Settings
		{
			public const Char ConnectionsSeparator = '\n';
			public const Char ConnectionParamsSeparator = '\r';
		}
	}
}