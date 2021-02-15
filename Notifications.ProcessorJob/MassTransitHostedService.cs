using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Notifications.ProcessorJob
{
    internal class MassTransitHostedService : IHostedService
    {
        private readonly IBusControl _busControl;

        public MassTransitHostedService(IBusControl busControl)
        {
            this._busControl = busControl;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await this._busControl.StartAsync(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await this._busControl.StopAsync(cancellationToken);
        }
    }
}