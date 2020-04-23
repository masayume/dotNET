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
