// ***********************************************************************
//  Assembly          : MediatRItemExtension.MediatRItemExtension.Tests
//  Author            : RzR
//  Created           : 15-06-2026 23:06
// 
//  Last Modified By : RzR
//  Last Modified On : 16-06-2026 19:55
//  ***********************************************************************
//  <copyright file="CreateOperationTests.cs" company="RzR SOFT & TECH">
//      Copyright (c) RzR. All rights reserved.
//  </copyright>
//  <contact>
//      https://iamrzr.dev/contact
//  </contact>
//  <summary></summary>
//  ***********************************************************************

#region U S I N G

using System.Linq;
using MediatRItemExtension.Enums;
using MediatRItemExtension.Enums.Codes;
using MediatRItemExtension.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace MediatRItemExtension.Tests.Models
{
    [TestClass]
    public class CreateOperationTests
    {
        [TestMethod]
        public void CreateOperation_DefaultFolderFileName_IsItem()
        {
            // Arrange & Act
            var op = new CreateOperation();

            // Assert
            Assert.AreEqual("Item", op.FolderFileName);
        }

        [TestMethod]
        public void CreateOperation_DefaultResponseTypeName_IsResponse()
        {
            // Arrange & Act
            var op = new CreateOperation();

            // Assert
            Assert.AreEqual("Response", op.ResponseTypeName);
        }

        [TestMethod]
        public void CreateOperation_DefaultHandlerInheritance_IsEmptyString()
        {
            // Arrange & Act
            var op = new CreateOperation();

            // Assert
            Assert.AreEqual(string.Empty, op.HandlerInheritance);
        }

        [TestMethod]
        public void CreateOperation_DefaultOperationInheritance_IsEmptyString()
        {
            // Arrange & Act
            var op = new CreateOperation();

            // Assert
            Assert.AreEqual(string.Empty, op.OperationInheritance);
        }

        [TestMethod]
        public void CreateOperation_DefaultCreateFolder_IsFalse()
        {
            // Arrange & Act
            var op = new CreateOperation();

            // Assert
            Assert.IsFalse(op.CreateFolder);
        }

        [TestMethod]
        public void CreateOperation_DefaultCreateOperationClass_IsFalse()
        {
            // Arrange & Act
            var op = new CreateOperation();

            // Assert
            Assert.IsFalse(op.CreateOperationClass);
        }

        [TestMethod]
        public void CreateOperation_DefaultCreateHandlerClass_IsFalse()
        {
            // Arrange & Act
            var op = new CreateOperation();

            // Assert
            Assert.IsFalse(op.CreateHandlerClass);
        }

        [TestMethod]
        public void CreateOperation_DefaultCreateValidatorClass_IsFalse()
        {
            // Arrange & Act
            var op = new CreateOperation();

            // Assert
            Assert.IsFalse(op.CreateValidatorClass);
        }

        [TestMethod]
        public void CreateOperation_DefaultIsOneFile_IsFalse()
        {
            // Arrange & Act
            var op = new CreateOperation();

            // Assert
            Assert.IsFalse(op.IsOneFile);
        }

        [TestMethod]
        public void CreateOperation_DefaultIsOneFolder_IsFalse()
        {
            // Arrange & Act
            var op = new CreateOperation();

            // Assert
            Assert.IsFalse(op.IsOneFolder);
        }

        [TestMethod]
        public void CreateOperation_DefaultIsOperationHandlerInOneFile_IsFalse()
        {
            // Arrange & Act
            var op = new CreateOperation();

            // Assert
            Assert.IsFalse(op.IsOperationHandlerInOneFile);
        }

        [TestMethod]
        public void CreateOperation_DefaultIsAutoImportUsingReferences_IsFalse()
        {
            // Arrange & Act
            var op = new CreateOperation();

            // Assert
            Assert.IsFalse(op.IsAutoImportUsingReferences);
        }

        [TestMethod]
        public void CreateOperation_DefaultIsValidatorWithLocalizationImport_IsFalse()
        {
            // Arrange & Act
            var op = new CreateOperation();

            // Assert
            Assert.IsFalse(op.IsValidatorWithLocalizationImport);
        }

        [TestMethod]
        public void CreateOperation_DefaultIsHandlerWithLocalizationImport_IsFalse()
        {
            // Arrange & Act
            var op = new CreateOperation();

            // Assert
            Assert.IsFalse(op.IsHandlerWithLocalizationImport);
        }

        [TestMethod]
        public void CreateOperation_DefaultOperation_IsQuery()
        {
            // Arrange & Act
            var op = new CreateOperation();

            // Assert
            Assert.AreEqual(OperationType.Query, op.Operation);
        }

        [TestMethod]
        public void CreateOperation_DefaultOperationProcessing_IsAsync()
        {
            // Arrange & Act
            var op = new CreateOperation();

            // Assert
            Assert.AreEqual(ProcessType.Async, op.OperationProcessing);
        }

        [TestMethod]
        public void CreateOperation_DefaultOperationBlueprint_IsClass()
        {
            // Arrange & Act
            var op = new CreateOperation();

            // Assert
            Assert.AreEqual(OperationBlueprintType.Class, op.OperationBlueprint);
        }

        [TestMethod]
        public void RequestHandlerIndent_WhenIsOneFileIsFalse_ReturnsTwoLevelIndent()
        {
            // Arrange
            var op = new CreateOperation { IsOneFile = false };

            // Act
            var result = op.RequestHandlerIndent;

            // Assert
            Assert.AreEqual("\t\t\t", result);
        }

        [TestMethod]
        public void RequestHandlerIndent_WhenIsOneFileIsTrue_ReturnsFourLevelIndent()
        {
            // Arrange
            var op = new CreateOperation { IsOneFile = true };

            // Act
            var result = op.RequestHandlerIndent;

            // Assert
            Assert.AreEqual("\t\t\t\t", result);
        }

        [TestMethod]
        public void OperationName_WithDefaultFolderFileNameAndQueryOperation_ReturnsItemQuery()
        {
            // Arrange
            var op = new CreateOperation
            {
                FolderFileName = "Item",
                Operation = OperationType.Query
            };

            // Act
            var result = op.OperationName;

            // Assert
            Assert.AreEqual("ItemQuery", result);
        }

        [TestMethod]
        public void OperationName_WithCustomFolderFileNameAndCommandOperation_ReturnsNamePlusCommand()
        {
            // Arrange
            var op = new CreateOperation
            {
                FolderFileName = "CreateUser",
                Operation = OperationType.Command
            };

            // Act
            var result = op.OperationName;

            // Assert
            Assert.AreEqual("CreateUserCommand", result);
        }

        [TestMethod]
        public void OperationName_WithNotificationOperation_ReturnsNamePlusNotification()
        {
            // Arrange
            var op = new CreateOperation
            {
                FolderFileName = "Order",
                Operation = OperationType.Notification
            };

            // Act
            var result = op.OperationName;

            // Assert
            Assert.AreEqual("OrderNotification", result);
        }

        [TestMethod]
        public void OperationName_WithStreamOperation_ReturnsNamePlusStream()
        {
            // Arrange
            var op = new CreateOperation
            {
                FolderFileName = "Events",
                Operation = OperationType.Stream
            };

            // Act
            var result = op.OperationName;

            // Assert
            Assert.AreEqual("EventsStream", result);
        }

        [TestMethod]
        public void HandlerName_WithDefaultFolderFileName_ReturnsItemHandler()
        {
            // Arrange
            var op = new CreateOperation { FolderFileName = "Item" };

            // Act
            var result = op.HandlerName;

            // Assert
            Assert.AreEqual("ItemHandler", result);
        }

        [TestMethod]
        public void HandlerName_WithCustomFolderFileName_ReturnsNamePlusHandler()
        {
            // Arrange
            var op = new CreateOperation { FolderFileName = "CreateUser" };

            // Act
            var result = op.HandlerName;

            // Assert
            Assert.AreEqual("CreateUserHandler", result);
        }

        [TestMethod]
        public void ValidatorName_WithDefaultFolderFileName_ReturnsItemValidator()
        {
            // Arrange
            var op = new CreateOperation { FolderFileName = "Item" };

            // Act
            var result = op.ValidatorName;

            // Assert
            Assert.AreEqual("ItemValidator", result);
        }

        [TestMethod]
        public void ValidatorName_WithCustomFolderFileName_ReturnsNamePlusValidator()
        {
            // Arrange
            var op = new CreateOperation { FolderFileName = "DeleteOrder" };

            // Act
            var result = op.ValidatorName;

            // Assert
            Assert.AreEqual("DeleteOrderValidator", result);
        }

        [TestMethod]
        public void AbstractValidator_WithDefaultsQueryOperation_ReturnsExpectedInheritanceString()
        {
            // Arrange
            var op = new CreateOperation
            {
                FolderFileName = "Item",
                Operation = OperationType.Query
            };

            // Act
            var result = op.AbstractValidator;

            // Assert
            Assert.AreEqual(" : AbstractValidator<ItemQuery>", result);
        }

        [TestMethod]
        public void AbstractValidator_WithCommandOperation_ReturnsExpectedInheritanceString()
        {
            // Arrange
            var op = new CreateOperation
            {
                FolderFileName = "Create",
                Operation = OperationType.Command
            };

            // Act
            var result = op.AbstractValidator;

            // Assert
            Assert.AreEqual(" : AbstractValidator<CreateCommand>", result);
        }

        [TestMethod]
        public void HandlerAccessor_WhenSyncAndStreamOperation_ReturnsPublic()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Sync,
                Operation = OperationType.Stream
            };

            // Act
            var result = op.HandlerAccessor;

            // Assert
            Assert.AreEqual("public ", result);
        }

        [TestMethod]
        public void HandlerAccessor_WhenSyncAndQueryOperation_ReturnsProtectedOverride()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Sync,
                Operation = OperationType.Query
            };

            // Act
            var result = op.HandlerAccessor;

            // Assert
            Assert.AreEqual("protected override ", result);
        }

        [TestMethod]
        public void HandlerAccessor_WhenSyncAndCommandOperation_ReturnsProtectedOverride()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Sync,
                Operation = OperationType.Command
            };

            // Act
            var result = op.HandlerAccessor;

            // Assert
            Assert.AreEqual("protected override ", result);
        }

        [TestMethod]
        public void HandlerAccessor_WhenSyncAndNotificationOperation_ReturnsProtectedOverride()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Sync,
                Operation = OperationType.Notification
            };

            // Act
            var result = op.HandlerAccessor;

            // Assert
            Assert.AreEqual("protected override ", result);
        }

        [TestMethod]
        public void HandlerAccessor_WhenAsyncAndQueryOperation_ReturnsPublicAsync()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Async,
                Operation = OperationType.Query
            };

            // Act
            var result = op.HandlerAccessor;

            // Assert
            Assert.AreEqual("public async ", result);
        }

        [TestMethod]
        public void HandlerAccessor_WhenAsyncAndStreamOperation_ReturnsPublicAsync()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Async,
                Operation = OperationType.Stream
            };

            // Act
            var result = op.HandlerAccessor;

            // Assert
            Assert.AreEqual("public async ", result);
        }

        [TestMethod]
        public void HandlerAccessor_WhenAsyncAndNotificationOperation_ReturnsPublicAsync()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Async,
                Operation = OperationType.Notification
            };

            // Act
            var result = op.HandlerAccessor;

            // Assert
            Assert.AreEqual("public async ", result);
        }

        [TestMethod]
        public void HandlerHandleReturnValueName_WhenSyncAndStreamOperation_ReturnsIAsyncEnumerableOfResponse()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Sync,
                Operation = OperationType.Stream,
                ResponseTypeName = "Response"
            };

            // Act
            var result = op.HandlerHandleReturnValueName;

            // Assert
            Assert.AreEqual("IAsyncEnumerable<Response>", result);
        }

        [TestMethod]
        public void HandlerHandleReturnValueName_WhenSyncAndQueryOperation_ReturnsVoid()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Sync,
                Operation = OperationType.Query
            };

            // Act
            var result = op.HandlerHandleReturnValueName;

            // Assert
            Assert.AreEqual("void", result);
        }

        [TestMethod]
        public void HandlerHandleReturnValueName_WhenSyncAndCommandOperation_ReturnsVoid()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Sync,
                Operation = OperationType.Command
            };

            // Act
            var result = op.HandlerHandleReturnValueName;

            // Assert
            Assert.AreEqual("void", result);
        }

        [TestMethod]
        public void HandlerHandleReturnValueName_WhenSyncAndNotificationOperation_ReturnsVoid()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Sync,
                Operation = OperationType.Notification
            };

            // Act
            var result = op.HandlerHandleReturnValueName;

            // Assert
            Assert.AreEqual("void", result);
        }

        [TestMethod]
        public void HandlerHandleReturnValueName_WhenAsyncAndStreamOperation_ReturnsIAsyncEnumerableOfResponse()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Async,
                Operation = OperationType.Stream,
                ResponseTypeName = "Response"
            };

            // Act
            var result = op.HandlerHandleReturnValueName;

            // Assert
            Assert.AreEqual("IAsyncEnumerable<Response>", result);
        }

        [TestMethod]
        public void HandlerHandleReturnValueName_WhenAsyncAndNotificationOperation_ReturnsTask()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Async,
                Operation = OperationType.Notification
            };

            // Act
            var result = op.HandlerHandleReturnValueName;

            // Assert
            Assert.AreEqual("Task", result);
        }

        [TestMethod]
        public void HandlerHandleReturnValueName_WhenAsyncAndQueryOperation_ReturnsTaskOfResponse()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Async,
                Operation = OperationType.Query,
                ResponseTypeName = "Response"
            };

            // Act
            var result = op.HandlerHandleReturnValueName;

            // Assert
            Assert.AreEqual("Task<Response>", result);
        }

        [TestMethod]
        public void HandlerHandleReturnValueName_WhenAsyncAndCommandOperation_ReturnsTaskOfResponse()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Async,
                Operation = OperationType.Command,
                ResponseTypeName = "Response"
            };

            // Act
            var result = op.HandlerHandleReturnValueName;

            // Assert
            Assert.AreEqual("Task<Response>", result);
        }

        [TestMethod]
        public void
            HandlerHandleReturnValueName_WhenAsyncAndQueryOperationWithCustomResponseType_ReturnsTaskOfCustomType()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Async,
                Operation = OperationType.Query,
                ResponseTypeName = "UserDto"
            };

            // Act
            var result = op.HandlerHandleReturnValueName;

            // Assert
            Assert.AreEqual("Task<UserDto>", result);
        }

        [TestMethod]
        public void RequestInterface_WhenQueryOperationAndNoInheritance_ReturnsIRequestOfResponse()
        {
            // Arrange
            var op = new CreateOperation
            {
                Operation = OperationType.Query,
                OperationInheritance = "",
                ResponseTypeName = "Response"
            };

            // Act
            var result = op.RequestInterface;

            // Assert
            Assert.AreEqual(" : IRequest<Response>", result);
        }

        [TestMethod]
        public void RequestInterface_WhenQueryOperationAndInheritanceSet_PrependInheritanceBeforeIRequest()
        {
            // Arrange
            var op = new CreateOperation
            {
                Operation = OperationType.Query,
                OperationInheritance = "IMyBase",
                ResponseTypeName = "Response"
            };

            // Act
            var result = op.RequestInterface;

            // Assert
            Assert.AreEqual(" : IMyBase, IRequest<Response>", result);
        }

        [TestMethod]
        public void RequestInterface_WhenCommandOperationAndNoInheritance_ReturnsIRequestOfResponse()
        {
            // Arrange
            var op = new CreateOperation
            {
                Operation = OperationType.Command,
                OperationInheritance = "",
                ResponseTypeName = "Response"
            };

            // Act
            var result = op.RequestInterface;

            // Assert
            Assert.AreEqual(" : IRequest<Response>", result);
        }

        [TestMethod]
        public void RequestInterface_WhenCommandOperationAndInheritanceSet_PrependInheritanceBeforeIRequest()
        {
            // Arrange
            var op = new CreateOperation
            {
                Operation = OperationType.Command,
                OperationInheritance = "ICommandBase",
                ResponseTypeName = "Response"
            };

            // Act
            var result = op.RequestInterface;

            // Assert
            Assert.AreEqual(" : ICommandBase, IRequest<Response>", result);
        }

        [TestMethod]
        public void RequestInterface_WhenNotificationOperationAndNoInheritance_ReturnsINotificationOfResponse()
        {
            // Arrange
            var op = new CreateOperation
            {
                Operation = OperationType.Notification,
                OperationInheritance = "",
                ResponseTypeName = "Response"
            };

            // Act
            var result = op.RequestInterface;

            // Assert
            Assert.AreEqual(" : INotification<Response>", result);
        }

        [TestMethod]
        public void RequestInterface_WhenNotificationOperationAndInheritanceSet_PrependInheritanceBeforeINotification()
        {
            // Arrange
            var op = new CreateOperation
            {
                Operation = OperationType.Notification,
                OperationInheritance = "IEventBase",
                ResponseTypeName = "Response"
            };

            // Act
            var result = op.RequestInterface;

            // Assert
            Assert.AreEqual(" : IEventBase, INotification<Response>", result);
        }

        [TestMethod]
        public void RequestInterface_WhenStreamOperationAndNoInheritance_ReturnsIStreamRequestOfResponse()
        {
            // Arrange
            var op = new CreateOperation
            {
                Operation = OperationType.Stream,
                OperationInheritance = "",
                ResponseTypeName = "Response"
            };

            // Act
            var result = op.RequestInterface;

            // Assert
            Assert.AreEqual(" : IStreamRequest<Response>", result);
        }

        [TestMethod]
        public void RequestInterface_WhenStreamOperationAndInheritanceSet_PrependInheritanceBeforeIStreamRequest()
        {
            // Arrange
            var op = new CreateOperation
            {
                Operation = OperationType.Stream,
                OperationInheritance = "IStreamBase",
                ResponseTypeName = "Response"
            };

            // Act
            var result = op.RequestInterface;

            // Assert
            Assert.AreEqual(" : IStreamBase, IStreamRequest<Response>", result);
        }

        [TestMethod]
        public void HandlerInterface_WhenSyncQueryAndNoHandlerInheritance_ReturnsRequestHandlerWithTypeArgs()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Sync,
                Operation = OperationType.Query,
                FolderFileName = "Item",
                ResponseTypeName = "Response",
                HandlerInheritance = ""
            };

            // Act
            var result = op.HandlerInterface;

            // Assert
            Assert.AreEqual(" : RequestHandler<ItemQuery, Response>", result);
        }

        [TestMethod]
        public void HandlerInterface_WhenSyncCommandAndNoHandlerInheritance_ReturnsRequestHandlerWithTypeArgs()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Sync,
                Operation = OperationType.Command,
                FolderFileName = "Create",
                ResponseTypeName = "Response",
                HandlerInheritance = ""
            };

            // Act
            var result = op.HandlerInterface;

            // Assert
            Assert.AreEqual(" : RequestHandler<CreateCommand, Response>", result);
        }

        [TestMethod]
        public void
            HandlerInterface_WhenSyncNotificationAndNoHandlerInheritance_ReturnsNotificationHandlerWithTypeArgs()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Sync,
                Operation = OperationType.Notification,
                FolderFileName = "Order",
                ResponseTypeName = "Response",
                HandlerInheritance = ""
            };

            // Act
            var result = op.HandlerInterface;

            // Assert
            Assert.AreEqual(" : NotificationHandler<OrderNotification, Response>", result);
        }

        [TestMethod]
        public void HandlerInterface_WhenSyncStreamAndNoHandlerInheritance_ReturnsIStreamRequestHandlerWithTypeArgs()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Sync,
                Operation = OperationType.Stream,
                FolderFileName = "Events",
                ResponseTypeName = "Response",
                HandlerInheritance = ""
            };

            // Act
            var result = op.HandlerInterface;

            // Assert
            Assert.AreEqual(" : IStreamRequestHandler<EventsStream, Response>", result);
        }

        [TestMethod]
        public void HandlerInterface_WhenSyncQueryAndHandlerInheritanceSet_InsertsInheritanceBeforeInterface()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Sync,
                Operation = OperationType.Query,
                FolderFileName = "Item",
                ResponseTypeName = "Response",
                HandlerInheritance = "IMyBase"
            };

            // Act
            var result = op.HandlerInterface;

            // Assert
            Assert.AreEqual(" : IMyBase, RequestHandler<ItemQuery, Response>", result);
        }

        [TestMethod]
        public void HandlerInterface_WhenSyncNotificationAndHandlerInheritanceSet_InsertsInheritanceBeforeInterface()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Sync,
                Operation = OperationType.Notification,
                FolderFileName = "Alert",
                ResponseTypeName = "Response",
                HandlerInheritance = "IAlertBase"
            };

            // Act
            var result = op.HandlerInterface;

            // Assert
            Assert.AreEqual(" : IAlertBase, NotificationHandler<AlertNotification, Response>", result);
        }

        [TestMethod]
        public void HandlerInterface_WhenAsyncQueryAndNoHandlerInheritance_ReturnsIRequestHandlerWithTypeArgs()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Async,
                Operation = OperationType.Query,
                FolderFileName = "Item",
                ResponseTypeName = "Response",
                HandlerInheritance = ""
            };

            // Act
            var result = op.HandlerInterface;

            // Assert
            Assert.AreEqual(" : IRequestHandler<ItemQuery, Response>", result);
        }

        [TestMethod]
        public void HandlerInterface_WhenAsyncCommandAndNoHandlerInheritance_ReturnsIRequestHandlerWithTypeArgs()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Async,
                Operation = OperationType.Command,
                FolderFileName = "Delete",
                ResponseTypeName = "Response",
                HandlerInheritance = ""
            };

            // Act
            var result = op.HandlerInterface;

            // Assert
            Assert.AreEqual(" : IRequestHandler<DeleteCommand, Response>", result);
        }

        [TestMethod]
        public void
            HandlerInterface_WhenAsyncNotificationAndNoHandlerInheritance_ReturnsINotificationHandlerWithTypeArgs()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Async,
                Operation = OperationType.Notification,
                FolderFileName = "Payment",
                ResponseTypeName = "Response",
                HandlerInheritance = ""
            };

            // Act
            var result = op.HandlerInterface;

            // Assert
            Assert.AreEqual(" : INotificationHandler<PaymentNotification, Response>", result);
        }

        [TestMethod]
        public void HandlerInterface_WhenAsyncStreamAndNoHandlerInheritance_ReturnsIStreamRequestHandlerWithTypeArgs()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Async,
                Operation = OperationType.Stream,
                FolderFileName = "Log",
                ResponseTypeName = "Response",
                HandlerInheritance = ""
            };

            // Act
            var result = op.HandlerInterface;

            // Assert
            Assert.AreEqual(" : IStreamRequestHandler<LogStream, Response>", result);
        }

        [TestMethod]
        public void HandlerInterface_WhenAsyncQueryAndHandlerInheritanceSet_InsertsInheritanceBeforeInterface()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Async,
                Operation = OperationType.Query,
                FolderFileName = "Product",
                ResponseTypeName = "Response",
                HandlerInheritance = "IHandlerBase"
            };

            // Act
            var result = op.HandlerInterface;

            // Assert
            Assert.AreEqual(" : IHandlerBase, IRequestHandler<ProductQuery, Response>", result);
        }

        [TestMethod]
        public void HandlerInterface_WhenAsyncNotificationAndHandlerInheritanceSet_InsertsInheritanceBeforeInterface()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Async,
                Operation = OperationType.Notification,
                FolderFileName = "Email",
                ResponseTypeName = "Response",
                HandlerInheritance = "INotifyBase"
            };

            // Act
            var result = op.HandlerInterface;

            // Assert
            Assert.AreEqual(" : INotifyBase, INotificationHandler<EmailNotification, Response>", result);
        }

        [TestMethod]
        public void HandlerInterface_WhenAsyncStreamAndHandlerInheritanceSet_InsertsInheritanceBeforeInterface()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Async,
                Operation = OperationType.Stream,
                FolderFileName = "Feed",
                ResponseTypeName = "Response",
                HandlerInheritance = "IStreamBase"
            };

            // Act
            var result = op.HandlerInterface;

            // Assert
            Assert.AreEqual(" : IStreamBase, IStreamRequestHandler<FeedStream, Response>", result);
        }

        [TestMethod]
        public void HandlerInterface_WhenAsyncQueryAndCustomResponseType_ReflectsCustomTypeInTypeArgs()
        {
            // Arrange
            var op = new CreateOperation
            {
                OperationProcessing = ProcessType.Async,
                Operation = OperationType.Query,
                FolderFileName = "User",
                ResponseTypeName = "UserDto",
                HandlerInheritance = ""
            };

            // Act
            var result = op.HandlerInterface;

            // Assert
            Assert.AreEqual(" : IRequestHandler<UserQuery, UserDto>", result);
        }

        [TestMethod]
        public void GetGeneratedFiles_PerFileLayoutWithAllClasses_ReturnsOperationHandlerAndValidator()
        {
            // Arrange
            var op = new CreateOperation
            {
                FolderFileName = "GetRecord",
                Operation = OperationType.Query,
                CreateOperationClass = true,
                CreateHandlerClass = true,
                CreateValidatorClass = true,
                IsOneFile = false,
                IsOperationHandlerInOneFile = false
            };

            // Act
            var files = op.GetGeneratedFiles().ToList();

            // Assert
            Assert.AreEqual(3, files.Count);
            CollectionAssert.AreEquivalent(
                new[] { ReqInfoCodeType.RF0006, ReqInfoCodeType.RF0007, ReqInfoCodeType.RF0008 },
                files.Select(f => f.Code).ToArray());
            Assert.IsTrue(files.Any(f => f.FileName == "GetRecordQuery.cs" && f.TypeName == "GetRecordQuery"));
            Assert.IsTrue(files.Any(f => f.FileName == "GetRecordHandler.cs" && f.TypeName == "GetRecordHandler"));
            Assert.IsTrue(files.Any(f => f.FileName == "GetRecordValidator.cs" && f.TypeName == "GetRecordValidator"));
        }

        [TestMethod]
        public void GetGeneratedFiles_OneFileLayout_ReturnsOnlyOperation()
        {
            // Arrange
            var op = new CreateOperation
            {
                FolderFileName = "GetRecord",
                Operation = OperationType.Query,
                CreateOperationClass = true,
                CreateHandlerClass = true,
                CreateValidatorClass = true,
                IsOneFile = true
            };

            // Act
            var files = op.GetGeneratedFiles().ToList();

            // Assert
            Assert.AreEqual(1, files.Count);
            Assert.AreEqual(ReqInfoCodeType.RF0006, files[0].Code);
            Assert.AreEqual("GetRecordQuery.cs", files[0].FileName);
            Assert.AreEqual("GetRecordQuery", files[0].TypeName);
        }

        [TestMethod]
        public void GetGeneratedFiles_OperationHandlerInOneFileLayout_ReturnsOperationAndValidator()
        {
            // Arrange
            var op = new CreateOperation
            {
                FolderFileName = "GetRecord",
                Operation = OperationType.Query,
                CreateOperationClass = true,
                CreateHandlerClass = true,
                CreateValidatorClass = true,
                IsOneFile = false,
                IsOperationHandlerInOneFile = true
            };

            // Act
            var files = op.GetGeneratedFiles().ToList();

            // Assert
            Assert.AreEqual(2, files.Count);
            CollectionAssert.AreEquivalent(
                new[] { ReqInfoCodeType.RF0006, ReqInfoCodeType.RF0008 },
                files.Select(f => f.Code).ToArray());
            Assert.IsFalse(files.Any(f => f.Code == ReqInfoCodeType.RF0007));
        }

        [TestMethod]
        public void GetGeneratedFiles_CommandOperationType_UsesCommandSuffixInNames()
        {
            // Arrange
            var op = new CreateOperation
            {
                FolderFileName = "GetRecord",
                Operation = OperationType.Command,
                CreateOperationClass = true,
                IsOneFile = false
            };

            // Act
            var files = op.GetGeneratedFiles().ToList();

            // Assert
            Assert.AreEqual(1, files.Count);
            Assert.AreEqual("GetRecordCommand.cs", files[0].FileName);
            Assert.AreEqual("GetRecordCommand", files[0].TypeName);
        }

        [TestMethod]
        public void GetGeneratedFiles_WhenValidatorNotRequested_ExcludesValidator()
        {
            // Arrange
            var op = new CreateOperation
            {
                FolderFileName = "GetRecord",
                Operation = OperationType.Query,
                CreateOperationClass = true,
                CreateHandlerClass = true,
                CreateValidatorClass = false,
                IsOneFile = false,
                IsOperationHandlerInOneFile = false
            };

            // Act
            var files = op.GetGeneratedFiles().ToList();

            // Assert
            Assert.AreEqual(2, files.Count);
            Assert.IsFalse(files.Any(f => f.Code == ReqInfoCodeType.RF0008));
        }

        [TestMethod]
        public void GetGeneratedFiles_WhenOperationClassNotRequested_ExcludesOperation()
        {
            // Arrange
            var op = new CreateOperation
            {
                FolderFileName = "GetRecord",
                Operation = OperationType.Query,
                CreateOperationClass = false,
                CreateHandlerClass = true,
                CreateValidatorClass = true,
                IsOneFile = false,
                IsOperationHandlerInOneFile = false
            };

            // Act
            var files = op.GetGeneratedFiles().ToList();

            // Assert
            Assert.AreEqual(2, files.Count);
            Assert.IsFalse(files.Any(f => f.Code == ReqInfoCodeType.RF0006));
            Assert.IsTrue(files.Any(f => f.Code == ReqInfoCodeType.RF0007));
            Assert.IsTrue(files.Any(f => f.Code == ReqInfoCodeType.RF0008));
        }
    }
}