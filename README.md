Studio-AssemblyResolver
=======================

This library is build to help SDL Studio developers who are wokring on standalone plugins. One of the limitation for this type of plugins is the fact that is has to be deployed in the same folder with Studio. This is caused by the fact that Studio SDK requires assembly that are available only in that location

## Getting started

Studio-AssemblyResolver is available on [NuGet](https://www.nuget.org/packages/Studio.AssemblyResolver/).

```
Install-Package Studio.AssemblyResolver
```

##How it works?

The library uses [AppDomain](http://msdn.microsoft.com/en-us/library/system.appdomain%28v=vs.110%29.aspx) class to obtain the current domain and register to AssemblyResolve event. This event is triggered for each assembly that is needed by the application. The library has also a mechanism to resolve the path to the Studio installation folder. Once it determines the Studio installation path is looking in that place after the required assembly.

##Studio path resolve

In order to get Studio install path the library looks in Program Files\SDL\ ... or in the registry. If you would like to provide a different path resolver you can implement IPathResolve interface and use the following syntax:
```csharp
AssemblyResolver.WithPathResolver(pathResolvers).Resolve();
```
##Contribution

You want to add a new functionality or you spot a bug please fill free to create a [pull request](http://www.codenewbie.org/blogs/how-to-make-a-pull-request) with your changes.

##Development Prerequisites

* [Visual Studio 2013](http://www.visualstudio.com/downloads/download-visual-studio-vs) - express/community edition can be used

##Issues

If you find an issue you report it [here](https://github.com/cromica/Studio-AssemblyResolver/issues).


