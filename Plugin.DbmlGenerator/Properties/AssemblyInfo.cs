﻿using System.Reflection;
using System.Runtime.InteropServices;

[assembly: Guid("2f435762-4bcb-4567-ae99-ec96c7e6c426")]
[assembly: System.CLSCompliant(true)]

#if NETCOREAPP
[assembly: AssemblyMetadata("ProjectUrl", "https://github.com/DKorablin/Plugin.DbmlGenerator")]
#else

[assembly: AssemblyDescription("LINQ to SQL (dbml) generator plugin from Microsoft SQL Server stored procedures")]
[assembly: AssemblyCopyright("Copyright © Danila Korablin 2010-2018")]
#endif