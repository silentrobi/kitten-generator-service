using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KittenGeneratorService.Application.SeedWork
{
    public interface ICommandHandler<in TCommand> :
        IRequestHandler<TCommand> where TCommand : ICommand
    {
        new Task<Unit> Handle(TCommand command, CancellationToken cancellationToken);
    }

    public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
        new Task<TResult> Handle(TCommand command, CancellationToken cancellationToken);
    }
}
