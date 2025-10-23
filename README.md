# GitVersionTest

This project demonstrates a workaround to enable [GitVersion.MsBuild](https://www.nuget.org/packages/GitVersion.MsBuild) 6.x integration for projects running in the Visual Studio IDE.

## Overview

GitVersion automates semantic versioning based on your Git history. This sample shows how to configure your `.csproj` and use the generated version information in your application.

## How It Works

 - The project uses the `GitVersion.MsBuild` NuGet package.
 - The `.csproj` file includes a custom MSBuild target (`GetVersionForVisualStudio`) to generate version info using `dotnet gitversion`.
 - Version metadata is injected into the assembly and accessed at runtime.

## Files of Interest

 - `GitVersionTest.csproj` : MSBuild configuration and GitVersion integration.
 - `Program.cs` : Example code showing how to read GitVersion metadata from the assembly at runtime.

## References

 - [GitVersion Discussion #4169](https://github.com/GitTools/GitVersion/discussions/4169)
 - [GitVersion Discussion #4130](https://github.com/GitTools/GitVersion/discussions/4130)

