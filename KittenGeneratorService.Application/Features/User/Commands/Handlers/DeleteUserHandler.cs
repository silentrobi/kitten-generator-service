using KittenGeneratorService.Application.Features.User.Repositories;
using KittenGeneratorService.Application.SeedWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KittenGeneratorService.Application.Features.User.Commands.Handlers
{
    public class DeleteUserHandler : ICommandHandler<DeleteUser>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteUser command, CancellationToken cancellationToken)
        {
            var user = _userRepository.Find(command.Id);

            if (user == null)
            {
                //throw expection
            }

            _userRepository.Delete(user);

            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
