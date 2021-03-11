using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SuperTool.Features.When
{
    public static class When
    {
        public class Query : IRequest<Response>
        {
        }

        public class Response
        {
            public DateTime CurrentTime { get; set; }
        }

        public class Handler : IRequestHandler<Query, Response>
        {
            public Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = new Response
                {
                    CurrentTime = DateTime.UtcNow
                };

                return Task.FromResult(response);
            }
        }
    }
}
