using Microsoft.AspNetCore.Mvc;
using Notifications.Dto;
using System.Threading.Tasks;
using MassTransit;
using Notifications.Contracts; 
using Newtonsoft.Json;
using System.Text;

namespace Notification.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public UsersController(IPublishEndpoint publishEndpoint)
        {
            this._publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto userDto)
        { 
            await this._publishEndpoint.Publish<INewUserAdded>(new { 
                Data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(userDto))
            });  

            return Accepted();
        }
    }
}
