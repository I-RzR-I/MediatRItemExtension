// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtensionV2K19
//  Author           : RzR
//  Created On       : 2025-03-24 15:51
// 
//  Last Modified By : RzR
//  Last Modified On : 2025-03-24 15:51
// ***********************************************************************
//  <copyright file="VersionCheckResultType.cs" company="RzR SOFT & TECH">
//   Copyright © RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

namespace MediatRItemExtension.Enums
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Values that represent version check result types.
    /// </summary>
    /// =================================================================================================
    public enum VersionCheckResultType
    {
        /// <summary>
        ///     An enum constant representing the option that the local version is last.
        /// </summary>
        UpToDate = 0,

        /// <summary>
        ///     An enum constant representing the option that a new version exists.
        /// </summary>
        ExistNewVersion = 1,

        /// <summary>
        ///     An enum constant representing the error in checking the new version.
        /// </summary>
        ErrorCheck = 2
    }
}