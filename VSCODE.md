# Setup VSCODE for C# Developers

from [Intro to VSCODE for C# Developers](https://www.youtube.com/watch?v=r5dtl9Uq9V0)

## Recommended Extensions

- C#
- GitLens
- vscode-icons
- Visual Studio Intellicode
- Nuget Package Manager

## Starting to Work

from [.NET Core command-line interface (CLI) tools](https://docs.microsoft.com/en-us/dotnet/core/tools/?tabs=netcore2x)

### Creating a Project with a Complete Solution

```
dotnet new sln -n 'VSCodeIntroSln'

dotnet new console -n "IntroUI"

dotnet new classlib -n "IntroLibrary"

# adding the project to the solution
dotnet sln VSCodeIntroSln.sln add ./IntroUI/IntroUI.csproj
dotnet sln VSCodeIntroSln.sln add ./IntroLibrary/IntroLibrary.csproj

# IntroUI must reference IntroLibrary
dotnet add IntroUI/IntroUI.csproj reference IntroLibrary/IntroLibrary.csproj

```

### Launching VSCode at this location

```
cd /dir1/dir2/C@ProjectDirectory/

code .

```

then VSCode will prompt to add assets to "build and debug" in .vscode directory

Remember to delete IntroLibrary/class1.cs

Create new class in IntroLibrary

In the project folder:

```
dotnet run
```

## Nuget


Adding packages modifies the ItemGroup/PackageReference inside the csproj file
Or it's possible to use CTRL + P and type nuget

```
dotnet add package Dapper
dotnet add package Serilog

```

```
  <ItemGroup>
    <PackageReference Include="Dapper" Version="2.0.35" />
  </ItemGroup>

```




## Debug

in the class to debud set a breakpoint to the line and press F5 to run the debugger

## Shortcuts

* CTRL + . - audoadd using statment for class in the project
* CTRL + space - brings up intellinsense
* cw - System.Console.WriteLine("This is a test");
* prop - public int MyProperty { get; set; }