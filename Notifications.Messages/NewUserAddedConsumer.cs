using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Notifications.Application.Commands;
using Notifications.Contracts;
using Notifications.Contracts.Base;
using Notifications.Dto;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Processor
{
    public class NewUserAddedConsumer : IConsumer<INewUserAdded>
    {
        private readonly IMapper _mapper; 
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public NewUserAddedConsumer(IMapper mapper, IServiceScopeFactory serviceScopeFactory)
        {
            this._mapper = mapper; 
            this._serviceScopeFactory = serviceScopeFactory;
        }

        public async Task Consume(ConsumeContext<INewUserAdded> context)
        {  
            ConsumeContext<IBaseEvent> c;
            if (context.TryGetMessage(out c))
            {
                var msg = c.Message.Data;

                var obj = JsonConvert.DeserializeObject<UserDto>(Encoding.ASCII.GetString(msg));

                // cqrs 
                var command = this._mapper.Map<UserCommand>(obj);

                // create another scope in order to obtain different instances for classes that are injected in handlers 
                using (var scope = this._serviceScopeFactory.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    await mediator.Send(command);
                }
            }; 
        }
    } 
}
