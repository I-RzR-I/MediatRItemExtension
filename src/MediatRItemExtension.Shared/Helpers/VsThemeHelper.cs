// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-27 20:04
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-27 20:04
// ***********************************************************************
//  <copyright file="VsThemeHelper.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MediatRItemExtension.Extensions.DataType;
// ReSharper disable EmptyGeneralCatchClause
// ReSharper disable AssignNullToNotNullAttribute

// ReSharper disable FieldCanBeMadeReadOnly.Global

namespace MediatRItemExtension.Helpers
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     The vs theme helper.
    /// </summary>
    /// =================================================================================================
    public static class VsThemeHelper
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the is using vs theme.
        /// </summary>
        /// =================================================================================================
        private static readonly Dictionary<UIElement, bool> IsUsingVsTheme = new Dictionary<UIElement, bool>();

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the original backgrounds.
        /// </summary>
        /// =================================================================================================
        private static readonly Dictionary<UIElement, object> OriginalBackgrounds = new Dictionary<UIElement, object>();

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The use vs theme property.
        /// </summary>
        /// =================================================================================================
        public static DependencyProperty UseVsThemeProperty = DependencyProperty.RegisterAttached("UseVsTheme", typeof(bool), typeof(VsThemeHelper), new PropertyMetadata(false, UseVsThemePropertyChanged));

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Use vs theme property changed.
        /// </summary>
        /// <param name="d">A DependencyObject to process.</param>
        /// <param name="e">Dependency property changed event information.</param>
        /// =================================================================================================
        private static void UseVsThemePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SetUseVsTheme((UIElement)d, (bool)e.NewValue);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets use vs theme.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">True to value.</param>
        /// =================================================================================================
        public static void SetUseVsTheme(UIElement element, bool value)
        {
            if (value)
            {
                if (!OriginalBackgrounds.ContainsKey(element) && element is Control c)
                {
                    OriginalBackgrounds[element] = c.Background;
                }

                ((ContentControl)element).ShouldBeThemed();
            }
            else
            {
                ((ContentControl)element).ShouldNotBeThemed();
            }

            IsUsingVsTheme[element] = value;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets use vs theme.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        /// =================================================================================================
        public static bool GetUseVsTheme(UIElement element)
        {
            return IsUsingVsTheme.TryGetValue(element, out bool value) && value;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Builds theme resources.
        /// </summary>
        /// <returns>
        ///     A ResourceDictionary.
        /// </returns>
        /// =================================================================================================
        private static ResourceDictionary BuildThemeResources()
        {
            var allResources = new ResourceDictionary();

            try
            {
                var shellResources = (ResourceDictionary)Application.LoadComponent(new Uri("Microsoft.VisualStudio.Platform.WindowManagement;component/Themes/ThemedDialogDefaultStyles.xaml", UriKind.Relative));
                var scrollStyleContainer = (ResourceDictionary)Application.LoadComponent(new Uri("Microsoft.VisualStudio.Shell.UI.Internal;component/Styles/ScrollBarStyle.xaml", UriKind.Relative));
                allResources.MergedDictionaries.Add(shellResources);
                allResources.MergedDictionaries.Add(scrollStyleContainer);

                allResources[typeof(ScrollViewer)] = new Style
                {
                    TargetType = typeof(ScrollViewer),
                    BasedOn = (Style)scrollStyleContainer[VsResourceKeys.ScrollViewerStyleKey]
                };

                allResources[typeof(TextBox)] = new Style
                {
                    TargetType = typeof(TextBox),
                    BasedOn = (Style)shellResources[typeof(TextBox)],
                    Setters =
                    {
                        new Setter(Control.PaddingProperty, new Thickness(5, 3, 5, 3))
                    }
                };

                allResources[typeof(ComboBox)] = new Style
                {
                    TargetType = typeof(ComboBox),
                    BasedOn = (Style)shellResources[typeof(ComboBox)],
                    Setters =
                    {
                        new Setter(Control.PaddingProperty, new Thickness(5, 3, 5, 3))
                    }
                };

                allResources[typeof(StackPanel)] = new Style
                {
                    TargetType = typeof(StackPanel),
                    BasedOn = (Style)shellResources[typeof(StackPanel)],
                    Setters =
                    {
                        new Setter(Control.PaddingProperty, new Thickness(5, 3, 5, 3))
                    }
                };

                allResources[typeof(CheckBox)] = new Style
                {
                    TargetType = typeof(CheckBox),
                    BasedOn = (Style)shellResources[typeof(CheckBox)],
                    Setters =
                    {
                        new Setter(Control.PaddingProperty, new Thickness(5, 3, 5, 3))
                    }
                };

                allResources[typeof(DialogWindow)] = new Style
                {
                    TargetType = typeof(DialogWindow),
                    BasedOn = (Style)shellResources[typeof(DialogWindow)],
                    Setters =
                    {
                        new Setter(Control.PaddingProperty, new Thickness(5, 3, 5, 3))
                    }
                };
                
                allResources[typeof(Label)] = new Style
                {
                    TargetType = typeof(Label),
                    BasedOn = (Style)shellResources[typeof(Label)],
                    Setters =
                    {
                        new Setter(Control.PaddingProperty, new Thickness(5, 3, 5, 3))
                    }
                };

                allResources[typeof(ToolBar)] = new Style
                {
                    TargetType = typeof(ToolBar),
                    BasedOn = (Style)shellResources[typeof(ToolBar)],
                    Setters =
                    {
                        new Setter(Control.PaddingProperty, new Thickness(5, 3, 5, 3))
                    }
                };
            }
            catch
            { }

            return allResources;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the theme resources.
        /// </summary>
        /// <value>
        ///     The theme resources.
        /// </value>
        /// =================================================================================================
        private static ResourceDictionary ThemeResources { get; } = BuildThemeResources();

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A FrameworkElement extension method that should be themed.
        /// </summary>
        /// <param name="control">The control to act on.</param>
        /// =================================================================================================
        private static void ShouldBeThemed(this FrameworkElement control)
        {
            if (control.Resources.IsNull())
            {
                control.Resources = ThemeResources;
            }
            else if (control.Resources != ThemeResources)
            {
                var d = new ResourceDictionary();
                d.MergedDictionaries.Add(ThemeResources);
                d.MergedDictionaries.Add(control.Resources);
                control.Resources = null;
                control.Resources = d;
            }

            if (control is Control c)
            {
                c.SetResourceReference(Control.BackgroundProperty, (string)EnvironmentColors.StartPageTabBackgroundBrushKey);
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A FrameworkElement extension method that should not be themed.
        /// </summary>
        /// <param name="control">The control to act on.</param>
        /// =================================================================================================
        private static void ShouldNotBeThemed(this FrameworkElement control)
        {
            if (control.Resources.IsNotNull())
            {
                if (control.Resources == ThemeResources)
                {
                    control.Resources = new ResourceDictionary();
                }
                else
                {
                    control.Resources.MergedDictionaries.Remove(ThemeResources);
                }
            }

            //If we're themed now and we're something with a background property, reset it
            if (GetUseVsTheme(control) && control is Control c)
            {
                if (OriginalBackgrounds.TryGetValue(control, out object background))
                {
                    c.SetValue(Control.BackgroundProperty, background);
                }
                else
                {
                    c.ClearValue(Control.BackgroundProperty);
                }
            }
        }
    }
}