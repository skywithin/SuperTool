using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace SuperTool
{
    public class SuperToolHostedService : IHostedService
    {
        private ILogger<SuperToolHostedService> _logger { get; }

        public SuperToolHostedService(ILogger<SuperToolHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Hi from the command line!");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Bye from the command line!");
            return Task.CompletedTask;
        }
    }
}
