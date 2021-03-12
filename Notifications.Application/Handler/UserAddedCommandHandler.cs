using AutoMapper;
using MediatR;
using Notifications.Application.Commands;
using Notifications.Data.Abstractions;
using Notifications.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Notifications.Application.Handler
{
    public class UserAddedCommandHandler : IRequestHandler<UserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserAddedCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<bool> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            // save to database
            var model = this._mapper.Map<User>(request);
            this._unitOfWork.GetRepository<User>().Insert(model);
            return await this._unitOfWork.SaveChangesAsync(); 
        }
    }
}
