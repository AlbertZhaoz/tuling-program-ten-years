using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Abp.Albert.Console
{
    public class AlbertHostedService:IHostedService
    {
        public AlbertService AlbertService { get; set; }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            AlbertService.SayHello();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
