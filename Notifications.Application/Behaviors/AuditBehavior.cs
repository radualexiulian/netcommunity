using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Notifications.Application.Behaviors
{
    public class AuditBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest:class
    {
        private readonly ILogger<AuditBehavior<TRequest, TResponse>> _logger;

        public AuditBehavior(ILogger<AuditBehavior<TRequest, TResponse>> logger)
        {
            this._logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            // before handler
            _logger.LogInformation($"Entered AuditBehavior for request: {request} before handler");  

            var result = await next(); // handlerul

            // after handler
            _logger.LogInformation($"Entered AuditBehavior for request: {request} after handler");

            return result;
        }
    }
}
