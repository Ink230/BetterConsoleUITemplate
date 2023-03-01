try
{
  Log.Information("Initializing services...");

  IHost host = Host.CreateDefaultBuilder()
    .ConfigureAppConfiguration((context, configBuilder) =>
    {
      configBuilder
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile(@"AppSettings/appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"AppSettings/appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production"}.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables()
        .AddCommandLine(args);
    })
    .UseSerilog((context, configuration) =>
    {
      configuration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .Enrich.WithMachineName();
    })
    .ConfigureServices((context, services) =>
    {
      services.AddTransient<Application>();
    })
    .Build();

  Log.Information("Application starting...");

  //Start the app entry point
  await (host?.Services?.GetService<Application>()?.RunAsync() ?? throw new Exception("Invalid service initialization."));

  Log.Information("Application closing...");
}
catch (Exception ex)
{
  Log.Fatal(ex, "Application terminated unexpectedly.");
}
finally
{
  Log.CloseAndFlush();
}
