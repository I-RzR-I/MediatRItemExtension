// ***********************************************************************
//  Assembly         : MediatRItemExtension.MediatRItemExtension
//  Author           : RzR
//  Created On       : 2024-05-09 00:47
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-05-14 08:23
// ***********************************************************************
//  <copyright file="CreateOperation.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using MediatRItemExtension.Enums;

#endregion

namespace MediatRItemExtension.Models
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A create operation.
    /// </summary>
    /// =================================================================================================
    internal class CreateOperation
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the filename of the folder file.
        /// </summary>
        /// <value>
        ///     The filename of the folder file.
        /// </value>
        /// =================================================================================================
        internal string FolderFileName { get; set; } = "Item";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the name of the response type.
        /// </summary>
        /// <value>
        ///     The name of the response type.
        /// </value>
        /// =================================================================================================
        public string ResponseTypeName { get; set; } = "Response";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether the create folder.
        /// </summary>
        /// <value>
        ///     True if create folder, false if not.
        /// </value>
        /// =================================================================================================
        internal bool CreateFolder { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether the create operation class.
        /// </summary>
        /// <value>
        ///     True if create operation class, false if not.
        /// </value>
        /// =================================================================================================
        internal bool CreateOperationClass { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether the create handler class.
        /// </summary>
        /// <value>
        ///     True if create handler class, false if not.
        /// </value>
        /// =================================================================================================
        internal bool CreateHandlerClass { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether the create validator class.
        /// </summary>
        /// <value>
        ///     True if create validator class, false if not.
        /// </value>
        /// =================================================================================================
        internal bool CreateValidatorClass { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether this object is one file.
        /// </summary>
        /// <value>
        ///     True if this object is one file, false if not.
        /// </value>
        /// =================================================================================================
        internal bool IsOneFile { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether this object is one folder.
        /// </summary>
        /// <value>
        ///     True if this object is one folder, false if not.
        /// </value>
        /// =================================================================================================
        internal bool IsOneFolder { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether this object is operation handler in one file.
        /// </summary>
        /// <value>
        ///     True if this object is operation handler in one file, false if not.
        /// </value>
        /// =================================================================================================
        internal bool IsOperationHandlerInOneFile { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether this object is automatic import using
        ///     references.
        /// </summary>
        /// <value>
        ///     True if this object is automatic import using references, false if not.
        /// </value>
        /// =================================================================================================
        internal bool IsAutoImportUsingReferences { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the operation.
        /// </summary>
        /// <value>
        ///     The operation.
        /// </value>
        /// =================================================================================================
        internal OperationType Operation { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the operation processing.
        /// </summary>
        /// <value>
        ///     The operation processing.
        /// </value>
        /// =================================================================================================
        internal ProcessType OperationProcessing { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the request handler indent.
        /// </summary>
        /// <value>
        ///     The request handler indent.
        /// </value>
        /// =================================================================================================
        internal string RequestHandlerIndent => IsOneFile ? "\t\t\t\t" : "\t\t\t";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the name of the operation.
        /// </summary>
        /// <value>
        ///     The name of the operation.
        /// </value>
        /// =================================================================================================
        internal string OperationName => $"{FolderFileName}{Operation}";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the name of the handler.
        /// </summary>
        /// <value>
        ///     The name of the handler.
        /// </value>
        /// =================================================================================================
        internal string HandlerName => $"{FolderFileName}Handler";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the name of the validator.
        /// </summary>
        /// <value>
        ///     The name of the validator.
        /// </value>
        /// =================================================================================================
        internal string ValidatorName => $"{FolderFileName}Validator";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the abstract validator.
        /// </summary>
        /// <value>
        ///     The abstract validator.
        /// </value>
        /// =================================================================================================
        internal string AbstractValidator => $" : AbstractValidator<{FolderFileName}{Operation}>";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the handler accessor.
        /// </summary>
        /// <value>
        ///     The handler accessor.
        /// </value>
        /// =================================================================================================
        internal string HandlerAccessor => OperationProcessing == ProcessType.Sync ? "protected override " : "public async ";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the handler interface.
        /// </summary>
        /// <value>
        ///     The handler interface.
        /// </value>
        /// =================================================================================================
        internal string HandlerInterface
        {
            get
            {
                string interfaceStr;
                if (OperationProcessing == ProcessType.Sync)
                {
                    interfaceStr = Operation == OperationType.Notification ? " : NotificationHandler" : " : RequestHandler";
                }
                else
                {
                    interfaceStr = Operation == OperationType.Notification ? " : INotificationHandler" : " : IRequestHandler";
                }

                interfaceStr = $"{interfaceStr}<{OperationName}, {ResponseTypeName}>";

                return interfaceStr;
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the name of the handler handle return value.
        /// </summary>
        /// <value>
        ///     The name of the handler handle return value.
        /// </value>
        /// =================================================================================================
        internal string HandlerHandleReturnValueName
        {
            get
            {
                if (OperationProcessing == ProcessType.Sync)
                {
                    return "void";
                }
                else
                {
                    if (Operation == OperationType.Notification)
                    {
                        return "Task";
                    }

                    return "Task" + $"<{ResponseTypeName}>";
                }
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the request interface.
        /// </summary>
        /// <value>
        ///     The request interface.
        /// </value>
        /// =================================================================================================
        internal string RequestInterface
        {
            get
            {
                var interfaceStr = Operation == OperationType.Notification ? " : INotification" : " : IRequest";

                return $"{interfaceStr}<{ResponseTypeName}>";
            }
        }
    }
}