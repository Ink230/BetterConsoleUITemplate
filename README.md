## BetterConsoleUI Template
A dotnet project file to create a console application with Serilog Logging, Configuration and Dependency Injection configured. Some opinionated settings are set in launchsettings.json, and .editorconfig. AppSettings is its own folder which contains basic .json settings files as a demonstration.

## Places to Configure the Template After Project Creation
- Determinine appsettings and appsettings.env.json structures
- Configure environment varariable (on machine, in IDE...etc)
- Configure secrets.json if applicable
- Configure publish options (platform, contained, release folder...etc)
- Configure Serilog formatting

## Adding as a Visual Studio Project
```dotnet new --install /pathtofolder/BetterConsoleUITemplate```

## Remove as a Visual Studio Project
```dotnet new --uninstall /pathtofolder/BetterConsoleUITemplate```

## More Info
- Ensure the .template.config folder and its contents are present

https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates