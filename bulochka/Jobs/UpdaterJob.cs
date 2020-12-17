using bulochka.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bulochka.Jobs
{
    [DisallowConcurrentExecution]
    public class UpdateJob : IJob
    {
        private readonly ILogger<UpdateJob> _logger;
        private IServiceProvider scopeFactory;
        public UpdateJob(ILogger<UpdateJob> logger, IServiceProvider scopeFactory)
        {
            _logger = logger;
            this.scopeFactory = scopeFactory;
        }
        public Task Execute(IJobExecutionContext context)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BulochkaService>();
                db.DeleteExpired();
                return Task.CompletedTask;
            }
        }
    }
}
