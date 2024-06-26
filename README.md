| Name     | Details |
|----------|----------|
| <a href="https://marketplace.visualstudio.com/items?itemName=RzR.MediatRItemExtensionV2K19" target="_blank">`MediatRItemExtensionV2K19`</a> | Extension for Visual Studio 2019 |
| <a href="https://marketplace.visualstudio.com/items?itemName=RzR.MediatRItemExtensionV2K22" target="_blank">`MediatRItemExtensionV2K22`</a> | Extension for Visual Studio 2022 |

This is a relatively simple VS extension that allows you to create necessary classes when u use `MediatR` with `FluentValidation` nuget packages. Also, allows to save time and redirect it to more important tasks that are on the board or in the queue.

From the box are available functionalities as: 
* Save all classes in one file;
* Create a file for each class;
* Add import references (for `MediatR` and `FluentValidation`);
* Select how the request will be executed `Sync` or `Async`;
* Select which type of operation you want to create;
* Specify the name of the folder/file;
* Use one name for the folder/file where will be stored information;
* Select option if you want to add `IStringLocalizer` to Validator or/and to the Handler;
* Specify any base class which will be added to the operation class (`Query`, `Command`, `Notification`).


To understand more efficiently how you can use available functionalities please consult the [using documentation/file](docs/usage.md).

## Content
1. [USING](docs/usage.md)
1. [CHANGELOG](docs/CHANGELOG.md)
1. [BRANCH-GUIDE](docs/branch-guide.md)