using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KittenGeneratorService.Application.SeedWork
{
    public interface IQueryHandler<in TQuery, TResult>
        : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        new Task<TResult> Handle(TQuery query, CancellationToken cancellationToken);
    }
}
