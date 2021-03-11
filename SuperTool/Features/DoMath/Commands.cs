﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using McMaster.Extensions.CommandLineUtils;
using MediatR;

namespace SuperTool.Features.DoMath
{
    public static class Commands
    {
        [Command(Name = "math", Description = "Perform feats of mathematics")]
        public class DoMathCommand
        {
            [Option("-o|--operation", CommandOptionType.SingleValue, Description = "Operation to perform")]
            public MathOperation Operation { get; set; }

            [Option("-l|--left", CommandOptionType.SingleValue, Description = "Left side operand")]
            public double Left { get; set; }

            [Option("-r|--right", CommandOptionType.SingleValue, Description = "Right side operand")]
            public double Right { get; set; }

            private async Task OnExecute(IMediator mediator, IMapper mapper, IConsole console)
            {
                var command = mapper.Map<DoMath.Request>(this);

                var response = await mediator.Send(command);

                console.WriteLine($"{Left} {Operation} {Right} = {response?.Result}");
            }
        }
    }
}
