
namespace NileshWebApi
{
    public class EmailService : BackgroundService
    {
        private readonly ILogger<EmailService> _logger;
        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("TimeLoggerService started at: {time}", DateTimeOffset.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Current time: {time}", DateTimeOffset.Now);
                await Task.Delay(5000, stoppingToken); // Wait 5 seconds
            }

            _logger.LogInformation("TimeLoggerService is stopping at: {time}", DateTimeOffset.Now);
        }
    }
}
