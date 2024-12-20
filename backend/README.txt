Before starting work:
-install .NET SDK 8


VS Code extensions:
-IntelliCode for C# Dev Kit
-REST Client (used for testing)


Command to install necessary tools:
-dotnet tool restore


To fill Dev-specific information:
-rename appsettings.example.json into appsettings.Development.json
-override the placeholders with necessary data


Commands to run the code:
-dotnet build
-dotnet run


Command to format the code before committing:
-dotnet format


Use appsettings.json for general config and appsettings.Development.json for local overrides.


If you need to add new tool, use the following command so it can be added to the project dependencies: dotnet tool install toolname
