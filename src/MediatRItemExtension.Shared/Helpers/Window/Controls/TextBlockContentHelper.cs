// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2025-03-25 16:04
// 
//  Last Modified By : RzR
//  Last Modified On : 2025-03-25 22:30
// ***********************************************************************
//  <copyright file="TextBlockContentHelper.cs" company="RzR SOFT & TECH">
//   Copyright © RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using MediatRItemExtension.Enums;
using MediatRItemExtension.Extensions.DataType;

// ReSharper disable UnusedParameter.Local

#endregion

namespace MediatRItemExtension.Helpers.Window.Controls
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A text box content helper.
    /// </summary>
    /// =================================================================================================
    internal static class TextBoxContentHelper
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets text block text value.
        /// </summary>
        /// <param name="txtBlock">[in,out] The text block.</param>
        /// <param name="txtValue">The text value.</param>
        /// =================================================================================================
        internal static void SetTxtBlockTextValue(ref TextBlock txtBlock, string txtValue)
        {
            txtBlock.Text = txtValue;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets text block validation status.
        /// </summary>
        /// <param name="txtBlock">[in,out] The text block.</param>
        /// <param name="versionStatus">The version status.</param>
        /// =================================================================================================
        internal static void SetTxtBlockValidationStatus(ref TextBlock txtBlock, VersionCheckResultType versionStatus)
        {
            versionStatus = versionStatus.IsNull() ? VersionCheckResultType.ErrorCheck : versionStatus;

            txtBlock.Text = versionStatus switch
            {
                VersionCheckResultType.UpToDate => "☑",
                VersionCheckResultType.ExistNewVersion => "ℹ",
                VersionCheckResultType.ErrorCheck => "❎",
                _ => "❎"
            };

            txtBlock.Foreground = versionStatus switch
            {
                VersionCheckResultType.UpToDate => Brushes.Green,
                VersionCheckResultType.ExistNewVersion => Brushes.Blue,
                VersionCheckResultType.ErrorCheck => Brushes.Red,
                _ => Brushes.Red
            };

            var toolTip = new ToolTip();
            var stackPanel = new StackPanel();
            var titleBlock = new TextBlock
            {
                Text = "MediatR item extension version check status",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            var titleBorder = new Border
            {
                BorderBrush = Brushes.Silver,
                BorderThickness = new Thickness(0, 1, 0, 1),
                Margin = new Thickness(0, 8, 0, 0)
            };

            var runUpToDate = new Run("☑ -> The current extension version is up to date.");
            var runExistNewVersion = new Run("ℹ -> Is available a version or local vs marketplace is different.");
            var runErrorCheck = new Run("❎ -> An error occurred while try to check version status or can't be checked.");

            var toolTipBody = new TextBlock();
            toolTipBody.Inlines.Clear();

            toolTipBody.Inlines.Add(runUpToDate);
            toolTipBody.Inlines.Add(new LineBreak());

            toolTipBody.Inlines.Add(runExistNewVersion);
            toolTipBody.Inlines.Add(new LineBreak());

            toolTipBody.Inlines.Add(runErrorCheck);

            var panel = new WrapPanel();
            panel.Children.Add(toolTipBody);

            // Set tool tip data
            stackPanel.Children.Add(titleBlock);
            stackPanel.Children.Add(titleBorder);
            stackPanel.Children.Add(panel);

            toolTip.Content = stackPanel;
            txtBlock.ToolTip = toolTip;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets text block author.
        /// </summary>
        /// <param name="txtBlock">[in,out] The text block.</param>
        /// <param name="author">The author.</param>
        /// =================================================================================================
        internal static void SetTxtBlockAuthor(ref TextBlock txtBlock, string author)
        {
            txtBlock.Text = $"© {author}";
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets text block author with link.
        /// </summary>
        /// <param name="txtBlock">[in,out] The text block.</param>
        /// <param name="author">The author.</param>
        /// <param name="uri">URI of the resource.</param>
        /// =================================================================================================
        internal static void SetTxtBlockAuthorWithLink(ref TextBlock txtBlock, string author, string uri)
        {
            var run = new Run($"© {author}");

            var hyperlink = new Hyperlink(run)
            {
                NavigateUri = new Uri(uri)
            };
            hyperlink.RequestNavigate += (sender, args) =>
            {
                Process.Start(new ProcessStartInfo(args.Uri.AbsoluteUri));
                args.Handled = true;
            };
            hyperlink.Foreground = Brushes.Black;

            txtBlock.Inlines.Clear();
            txtBlock.Inlines.Add(hyperlink);
        }
    }
}