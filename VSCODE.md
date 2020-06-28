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

## Shortcuts

* cw - System.Console.WriteLine("This is a test");
* prop - public int MyProperty { get; set; }