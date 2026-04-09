// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-08 15:32
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-14 08:23
// ***********************************************************************
//  <copyright file="ObjectNameValue.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

using System.ComponentModel;

namespace MediatRItemExtension.Models
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     An object name value.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// =================================================================================================
    public class ObjectNameValue<T> : INotifyPropertyChanged
    {
        private bool _isEnabled = true;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        /// =================================================================================================
        public string Name { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        /// =================================================================================================
        public T Value { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether this object is enabled.
        /// </summary>
        /// <value>
        ///     True if this object is enabled, false if not.
        /// </value>
        /// =================================================================================================
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (_isEnabled == value) return;
                _isEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEnabled)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}