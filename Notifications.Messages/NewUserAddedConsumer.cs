using MassTransit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Notifications.Contracts;
using Notifications.Contracts.Base;
using Notifications.Dto;
using System;
using System.Text;
using System.Threading.Tasks; 

namespace Notifications.Processor
{
    public class NewUserAddedConsumer : IConsumer<INewUserAdded>
    {
        public async Task Consume(ConsumeContext<INewUserAdded> context)
        {
            ConsumeContext<IBaseEvent> c;
            if (context.TryGetMessage(out c))
            {
                var msg = c.Message.Data;

                var obj = JsonConvert.DeserializeObject<UserDto>(Encoding.ASCII.GetString(msg));
            }; 
        }
    } 
}
