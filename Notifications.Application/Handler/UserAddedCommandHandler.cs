using MediatR;
using Notifications.Application.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Notifications.Application.Handler
{
    public class UserAddedCommandHandler : IRequestHandler<UserCommand, bool>
    {
        public async Task<bool> Handle(UserCommand request, CancellationToken cancellationToken)
        {  
            // validations

            // save to database

            return true;
        }
    }
}
