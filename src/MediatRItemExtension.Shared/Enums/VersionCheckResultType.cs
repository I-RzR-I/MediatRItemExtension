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
        UpToDate = 0,

        ExistNewVersion = 1,

        ErrorCheck = 2
    }
}