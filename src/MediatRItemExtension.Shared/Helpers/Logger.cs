// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-16 23:54
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-17 14:06
// ***********************************************************************
//  <copyright file="Logger.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Diagnostics;
using MediatRItemExtension.Extensions.DataType;
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

#endregion

namespace MediatRItemExtension.Helpers
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A logger.
    /// </summary>
    /// =================================================================================================
    internal static class Logger
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The name.
        /// </summary>
        /// =================================================================================================
        private static string _name;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The pane.
        /// </summary>
        /// =================================================================================================
        private static IVsOutputWindowPane _pane;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The output.
        /// </summary>
        /// =================================================================================================
        private static IVsOutputWindow _output;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes this object.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="name">The name.</param>
        /// =================================================================================================
        internal static void Initialize(IServiceProvider provider, string name)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            _output = (IVsOutputWindow)provider.GetService(typeof(SVsOutputWindow));
            Assumes.Present(_output);

            _name = name;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Logs the given message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// =================================================================================================
        internal static void Log(object message)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            try
            {
                if (EnsurePane())
#pragma warning disable RS0030
                    _pane.OutputString($"{DateTime.Now}: {message}{Environment.NewLine}");
#pragma warning restore RS0030
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Ensures that pane.
        /// </summary>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        /// =================================================================================================
        private static bool EnsurePane()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            if (_pane.IsNull())
            {
                var guid = Guid.NewGuid();
                _output.CreatePane(ref guid, _name, 1, 1);
                _output.GetPane(ref guid, out _pane);
            }

            return _pane.IsNotNull();
        }
    }
}