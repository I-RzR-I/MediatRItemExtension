| Name     | Details | Version | Downloads | Installs |
|----------|----------|---------|-----------|----------|
| <a href="https://marketplace.visualstudio.com/items?itemName=RzR.MediatRItemExtensionV2K19" target="_blank">`MediatRItemExtensionV2K19`</a> | Extension for Visual Studio 2019 | ![Version](https://vsmarketplacebadges.dev/version-short/RzR.MediatRItemExtensionV2K19.svg?label=v) | ![Downloads](https://vsmarketplacebadges.dev/downloads-short/RzR.MediatRItemExtensionV2K19.svg) | ![Installs](https://vsmarketplacebadges.dev/installs-short/RzR.MediatRItemExtensionV2K19.svg) |
| <a href="https://marketplace.visualstudio.com/items?itemName=RzR.MediatRItemExtensionV2K22" target="_blank">`MediatRItemExtensionV2K22`</a> | Extension for Visual Studio 2022 | ![Version](https://vsmarketplacebadges.dev/version-short/RzR.MediatRItemExtensionV2K22.svg?label=v) | ![Downloads](https://vsmarketplacebadges.dev/downloads-short/RzR.MediatRItemExtensionV2K22.svg) | ![Installs](https://vsmarketplacebadges.dev/installs-short/RzR.MediatRItemExtensionV2K22.svg) |

`MediatRItemExtension` scaffolds the MediatR + FluentValidation boilerplate you write by hand on every feature: the operation class (Query, Command, Notification, or Stream), its handler, and its validator. You fill in a name and a few options in a tool window, click confirm, and the extension creates the files in the selected project folder — using directives included.

It targets developers working in Visual Studio 2019 or 2022 (also work on 2026) who already use `MediatR` and `FluentValidation` in their projects and want to stop writing the same structural boilerplate for every operation.

**Prerequisites:** the target project must already reference the `MediatR` and `FluentValidation` NuGet packages. The extension adds `using` directives that reference those namespaces; it does not install the packages itself.

## Overview

Activate the extension from any project folder via right-click → **MediatR Items Creation**, or with the keyboard shortcut `SHIFT + INSERT + M`.

  <div align="center" width="100%">
 <img src="docs/assets/main_window_v3.5.1.0.png"
     alt="Main window"
     style="float: center;" 
     width="100%"/> <br />
 </div> <br/>

The tool window lets you configure the operation type, execution model (sync/async), blueprint type (class or record), response type, file layout, and the operation name — then generates all required files in one step.

## Features

* Save all classes in one file
* Create a file for each class
* Add import references (for `MediatR` and `FluentValidation`)
* Select how the request will be executed: `Sync` or `Async`
* Select which type of operation you want to create
* Specify the name of the folder/file
* Use one name for the folder/file where information will be stored
* Select option if you want to add `IStringLocalizer` to the Validator or/and to the Handler
* Specify any base class to add to the operation class (`Query`, `Command`, `Notification`, `Stream`)
* Select the operation blueprint: `Class` or `Record`

## Example output

The examples below show what the extension generates. Class names and namespaces are derived from the name you enter in the tool window.

### Query operation and handler

```csharp
using System.Threading;
using MediatR;
using System;
using System.Threading.Tasks;

namespace ProjectNamespace.GetArticle
{
    public class GetArticleQuery : IRequest<int>
    {
    }

    public class GetArticleHandler : IRequestHandler<GetArticleQuery, int>
    {
        public async Task<int> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
```

### Validator

```csharp
using FluentValidation;

namespace ProjectNamespace.GetArticle
{
    public class GetArticleValidator : AbstractValidator<GetArticleQuery>
    {
    }
}
```

### With IStringLocalizer injected

When you check **Add to Validator** and **Add to Handler**, the extension adds the `IStringLocalizer` constructor parameter to both generated classes:

```csharp
using Microsoft.Extensions.Localization;
using FluentValidation;

namespace ProjectNamespace.GetArticle
{
    public class GetArticleValidator : AbstractValidator<GetArticleQuery>
    {
        public GetArticleValidator(IStringLocalizer stringLocalizer)
        {
        }
    }
}
```

```csharp
using Microsoft.Extensions.Localization;
using System.Threading;
using MediatR;
using System;
using System.Threading.Tasks;

namespace ProjectNamespace.GetArticle
{
    public class GetArticleHandler : IRequestHandler<GetArticleQuery, int>
    {
        public GetArticleHandler(IStringLocalizer stringLocalizer)
        {
        }

        public async Task<int> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
```

### Class vs Record blueprint

Selecting **Record** as the blueprint type changes the operation declaration keyword. Everything else (handler, validator, file layout) stays the same.

```csharp
// Blueprint: Class
public class GetArticleQuery : IRequest<int>
{
}

// Blueprint: Record
public record GetArticleQuery : IRequest<int>
{
}
```

### Operation inheritance

When you fill in the **Operation inheritance** field, the specified base class is inserted before the MediatR interface in the declaration:

```csharp
public class GetArticleQuery : BaseClass, IRequest<int>
{
}
```

## Content
1. [USING](docs/usage.md)
2. [CHANGELOG](docs/CHANGELOG.md)
3. [BRANCH-GUIDE](docs/branch-guide.md)
