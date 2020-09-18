# dotNET
C# examples

## dotnet --info

## create .NET project "files"
dotnet new console -o 01-files

## compile classes
csc -t:exe -define:DEBUG -out:files.exe FileProgram.cs FileProcessor.cs

## install references

example:
dotnet add package CvsHelper.json

```
 to install System.Runtime.Caching 
 1 - install Nuget Package Manager
   CTRL+P -> ext install jmrog.vscode-nuget-package-manager
 2 - press F1, search: nuget package manager: add package
   enter System.Runtime.Caching and proceed
 3 - restore from terminal
 dotnet restore
 4 - add reference at build time: -reference:System.Runtime.Caching.dll
 csc -t:exe -define:DEBUG -reference:System.Runtime.Caching.dll -out:files.exe FileProgram.cs FileProcessor.cs

 csc -t:exe -define:DEBUG -r:System.Runtime.Caching.dll -out:files.exe FileProgram.cs FileProcessor.cs

 csc -t:exe -define:DEBUG -r:<FULL_PATH>library.dll -out:files.exe FileProgram.cs FileProcessor.cs
```
## Resources

* [intro to VSCode for C# Developers](https://www.youtube.com/watch?v=r5dtl9Uq9V0)
* [15 C# Project Ideas: Beginner to Expert [With tutorial]](https://dev.to/nerdjfpb/15-c-project-ideas-beginner-to-expert-with-tutorial-iio)
* [C# developer - Build types](https://dev.to/samfieldscc/things-you-need-to-know-as-a-c-developer-build-types-2igl)
* [C# developer - Collections](https://dev.to/samfieldscc/things-you-need-to-know-as-a-c-developer-collections-md6)



