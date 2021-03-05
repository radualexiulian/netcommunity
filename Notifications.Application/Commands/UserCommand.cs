using MediatR;

namespace Notifications.Application.Commands
{
    public class UserCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
