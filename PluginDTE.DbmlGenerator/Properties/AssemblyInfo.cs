using System.Reflection;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
[assembly: Guid("2f435762-4bcb-4567-ae99-ec96c7e6c426")]
[assembly: System.CLSCompliant(true)]

#if NETCOREAPP
[assembly: AssemblyMetadata("ProjectUrl", "https://github.com/DKorablin/Plugin.DbmlGenerator")]
#else

[assembly: AssemblyTitle("Plugin.DbmlGenerator")]
[assembly: AssemblyDescription("LINQ to SQL (dbml) generator plugin from Microsoft SQL Server stored procedures")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
[assembly: AssemblyCompany("Danila Korablin")]
[assembly: AssemblyProduct("Plugin.DbmlGenerator")]
[assembly: AssemblyCopyright("Copyright © Danila Korablin 2010-2018")]
#endif