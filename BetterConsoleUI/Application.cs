namespace App;

public class Application
{
  private readonly IConfiguration _config;
  private readonly ILogger _logger;

  public Application(IConfiguration config, ILogger logger)
  {
    _config = config;
    _logger = logger;
  }

  public async Task RunAsync()
  {
    //Do something, ex:
    Console.WriteLine(Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT"));
    _logger.Information(_config.GetValue<string>("AppName"));
    _logger.Information("Application running...");
    await Task.FromResult(0);
    Console.ReadLine();
  }
}
