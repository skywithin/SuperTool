using McMaster.Extensions.CommandLineUtils;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Threading.Tasks;

namespace SuperTool
{
    [Command(Name = "SuperTool", Description = "Run helpful utilities for my application")]
    [HelpOption]
    [VersionOptionFromMember(MemberName = nameof(GetVersion))]
    [Subcommand(typeof(Features.When.Commands.WhenCommand))]
    internal class Program
    {
        public Program() { }

        private static async Task Main(string[] args)
        {
            await CreateHostBuilder()
                    .RunCommandLineApplicationAsync<Program>(args);
        }

        public static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                       .ConfigureServices((hostContext, services) =>
                       {
                           services.AddMediatR(typeof(Program).Assembly);

                           // turn off the startup messages logged that we won't be using
                           services.PostConfigure<ConsoleLifetimeOptions>(options => options.SuppressStatusMessages = true);
                       });
        }

        private int OnExecute(CommandLineApplication app, IConsole console)
        {
            console.WriteLine("You must specify a command");
            app.ShowHelp();
            return 1;
        }

        private string GetVersion()
        {
            return typeof(Program).Assembly
                ?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;
        }
    }
}
