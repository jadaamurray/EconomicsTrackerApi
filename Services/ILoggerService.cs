using Microsoft.Extensions.Logging;

public class MyService
{
    private readonly ILogger<MyService> _logger;

    public MyService(ILogger<MyService> logger)
    {
        _logger = logger;
    }

    public void ProcessData()
    {
        _logger.LogInformation("Processing data...");
        try
        {
            // Some logic here...
            _logger.LogDebug("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while processing data.");
        }
    }
}
