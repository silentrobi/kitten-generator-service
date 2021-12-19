using KittenGeneratorService.Application.Features.User.Repositories;
using KittenGeneratorService.Application.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KittenGeneratorService.Application.Features.User.Commands.Handlers
{
    public class UpdateUserHandler : ICommandHandler<UpdateUser, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Guid> Handle(UpdateUser command, CancellationToken cancellationToken)
        {
            var user = _userRepository.Find(command.Id);

            if(user == null)
            {
                //throw expection
            }

            user.Update(command.Username, command.Password, command.Role);

            await _unitOfWork.CompleteAsync();

            return user.Id;
        }
    }
}
