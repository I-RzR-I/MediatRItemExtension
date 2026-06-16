// ***********************************************************************
//  Assembly          : MediatRItemExtension.MediatRItemExtension.Tests
//  Author            : RzR
//  Created           : 15-06-2026 23:06
// 
//  Last Modified By : RzR
//  Last Modified On : 16-06-2026 19:51
//  ***********************************************************************
//  <copyright file="TestDescriptionEnum.cs" company="RzR SOFT & TECH">
//      Copyright (c) RzR. All rights reserved.
//  </copyright>
//  <contact>
//      https://iamrzr.dev/contact
//  </contact>
//  <summary></summary>
//  ***********************************************************************

#region U S I N G

using System.ComponentModel;

#endregion

namespace MediatRItemExtension.Tests.Extensions.DataType
{
    internal enum TestDescriptionEnum
    {
        [Description("My Description")] 
        WithDescription,

        WithoutDescription,

        [Description("")]
        WithEmptyDescription
    }
}