﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace SuperTool
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();
            await host.StartAsync();
            await host.StopAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                       .ConfigureServices((hostContext, services) =>
                       {
                           services.AddHostedService<SuperToolHostedService>();

                           // turn off the startup messages logged that we won't be using
                           services.PostConfigure<ConsoleLifetimeOptions>(options => options.SuppressStatusMessages = true);
                       });
        }
    }
}
