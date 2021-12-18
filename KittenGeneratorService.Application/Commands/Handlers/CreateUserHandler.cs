using KittenGeneratorService.Application.Repositories;
using KittenGeneratorService.Application.SeedWork;
using KittenGeneratorService.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KittenGeneratorService.Application.Commands.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateUser command, CancellationToken cancellationToken)
        {
            var user = User.Create(command.Username, command.Password, command.Email, command.Role);

            _userRepository.Add(user);
            await _unitOfWork.CompleteAsync();

            return user.Id;
        }
    }
}
