using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyWorkerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendEmail
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
