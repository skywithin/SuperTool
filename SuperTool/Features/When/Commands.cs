using System;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using MediatR;

namespace SuperTool.Features.When
{
    public static class Commands
    {
        [Command(Name = "when", Description = "Get the current time")]
        public class WhenCommand
        {
            public async Task OnExecute(IMediator mediator, IConsole console)
            {
                var response = await mediator.Send(new When.Query());
                console.WriteLine($"Current time: {response.CurrentTime:O}");
            }
        }
    }
}
