// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2026-04-08 21:04
// 
//  Last Modified By : RzR
//  Last Modified On : 2026-04-09 09:04
// ***********************************************************************
//  <copyright file="ItemsTemplateHelper.cs" company="RzR SOFT & TECH">
//   Copyright © RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System.IO;
using MediatRItemExtension.Extensions.DataType;
using MediatRItemExtension.Helpers;

#endregion

namespace MediatRItemExtension.Shared.Helpers
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     The items template helper.
    /// </summary>
    /// =================================================================================================
    internal static class ItemsTemplateHelper
    {
        private const string RecordFileOld = @"

namespace {project.Properties.Item(""DefaultNamespace"").Value}
{{
    record @RzRRecordTemplateName
    {
    }
}}";

        private const string RecordFile = @"using System;
using System.Collections.Generic;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;
$if$ ($targetframeworkversion$ >= 4.5)using System.Threading.Tasks;
$endif$
namespace $rootnamespace$
{
    record $safeitemrootname$
    {
    }
}";

        private const string RecordTemplateFile = @"<?xml version=""1.0"" encoding=""utf-8""?>
<VSTemplate Version=""3.0.0"" Type=""Item"" xmlns=""http://schemas.microsoft.com/developer/vstemplate/2005"">
  <TemplateData>
    <Name Package=""{FAE04EC1-301F-11d3-BF4B-00C04F79EFBC}"" ID=""2245"" />
    <Description Package=""{FAE04EC1-301F-11d3-BF4B-00C04F79EFBC}"" ID=""2262"" />
    <Icon Package=""{FAE04EC1-301F-11d3-BF4B-00C04F79EFBC}"" ID=""4515"" />
    <TemplateID>Microsoft.CSharp.Class</TemplateID>
    <ProjectType>CSharp</ProjectType>
    <SortOrder>90</SortOrder>
    <NumberOfParentCategoriesToRollUp>1</NumberOfParentCategoriesToRollUp>
    <DefaultName>RzRRecordTemplate.cs</DefaultName>
    <AppIdFilter>blend</AppIdFilter>
  </TemplateData>
  <TemplateContent>
    <ProjectItem ReplaceParameters=""true"">RzRRecordTemplate.cs</ProjectItem>
  </TemplateContent>
</VSTemplate>";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or create internal items template path.
        /// </summary>
        /// <returns>
        ///     The internal items template path.
        /// </returns>
        /// =================================================================================================
        internal static string GetOrCreateInternalItemsTemplatePath()
        {
            var vsixInfo = VsixInfoHelper.Instance.GetManifest();
            var tempDir = Path.Combine(vsixInfo.LocalPath, "ItemTemplates");

            if (Directory.Exists(tempDir).IsFalse())
                Directory.CreateDirectory(tempDir);

            return tempDir;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Creates custom record template.
        /// </summary>
        /// <returns>
        ///     The new custom record template.
        /// </returns>
        /// =================================================================================================
        internal static string CreateCustomRecordTemplate()
        {
            var tempDir = GetOrCreateInternalItemsTemplatePath();
            tempDir = Path.Combine(tempDir, "RzRRecordTemplate");

            var csPath = Path.Combine(tempDir, "RzRRecordTemplate.cs");
            var vsTemplatePath = Path.Combine(tempDir, "RzRRecordTemplate.vstemplate");

            if (File.Exists(csPath).IsFalse())
                File.WriteAllText(csPath, RecordFile);

            if (File.Exists(vsTemplatePath).IsFalse())
                File.WriteAllText(vsTemplatePath, RecordTemplateFile);

            return tempDir;
        }
    }
}