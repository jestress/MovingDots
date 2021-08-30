using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovingDots.API
{
    public class WeatherCronJob : CronJobService
    {
        private readonly ILogger<WeatherCronJob> _logger;

        public WeatherCronJob(IScheduleConfig<WeatherCronJob> config, ILogger<WeatherCronJob> logger)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob 3 starts.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} CronJob 3 is working.");
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob 3 is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}