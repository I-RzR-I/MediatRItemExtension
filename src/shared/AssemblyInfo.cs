using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
using MediatRItemExtension.Helpers;
using System;

[assembly: AssemblyTitle(InitResources.ProductName)]
[assembly: AssemblyDescription(InitResources.Description)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(InitResources.Author + " ®")]
[assembly: AssemblyProduct(InitResources.ProductName)]
[assembly: AssemblyCopyright("Copyright © 2022-2025 " + InitResources.Author + " All rights reserved.")]
[assembly: AssemblyTrademark("® " + InitResources.Author + "™")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]
[assembly: CLSCompliant(false)]

[assembly: AssemblyVersion(InitResources.Version)]
[assembly: AssemblyFileVersion(InitResources.Version)]
[assembly: NeutralResourcesLanguage("en-US")]
