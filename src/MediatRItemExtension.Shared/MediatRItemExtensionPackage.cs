// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-17 23:17
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-20 15:46
// ***********************************************************************
//  <copyright file="MediatRItemExtensionV2K22Package.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Runtime.InteropServices;
using System.Threading;
using MediatRItemExtension.Enums.Codes;
using MediatRItemExtension.Helpers;
using MediatRItemExtension.Services;
using Microsoft.VisualStudio.Shell;

#endregion

namespace MediatRItemExtension
{
    /// <summary>
    ///     This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The minimum requirement for a class to be considered a valid package for Visual Studio
    ///         is to implement the IVsPackage interface and register itself with the shell.
    ///         This package uses the helper classes defined inside the Managed Package Framework (MPF)
    ///         to do it: it derives from the Package class that provides the implementation of the
    ///         IVsPackage interface and uses the registration attributes defined in the framework to
    ///         register itself and its components with the shell. These attributes tell the pkgdef creation
    ///         utility what data to put into .pkgdef file.
    ///     </para>
    ///     <para>
    ///         To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...
    ///         &gt; in .vsixmanifest file.
    ///     </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(InitResources.ProductName, InitResources.Description, InitResources.Version)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(InitResources.PackageId)]
    public class MediatRItemExtensionPackage : AsyncPackage
    {
        /// <summary>
        ///     MediatRItemExtensionPackage GUID string.
        /// </summary>
        public const string PackageGuidString = InitResources.PackageId;

        #region Package Members

        /// <summary>
        ///     Initialization of the package; this method is called right after the package is sited, so this is the place
        ///     where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        /// <param name="cancellationToken">
        ///     A cancellation token to monitor for initialization cancellation, which can occur when
        ///     VS is shutting down.
        /// </param>
        /// <param name="progress">A provider for progress updates.</param>
        /// <returns>
        ///     A task representing the async work of package initialization, or an already completed task if there is none.
        ///     Do not return null from this method.
        /// </returns>
        protected override async System.Threading.Tasks.Task InitializeAsync(CancellationToken cancellationToken,
            IProgress<ServiceProgressData> progress)
        {
            try
            {
                Logger.Initialize(this, InitResources.PackageId);

                // When initialized asynchronously, the current thread may be a background thread at this point.
                // Do any initialization that requires the UI thread after switching to the UI thread.
                await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

                await MediatRItemInitializeService.InitializeAsync(this);
            }
            catch (Exception e)
            {
                Logger.Log(ErrorCodeType.E0001, e, true);
            }
        }

        #endregion
    }
}