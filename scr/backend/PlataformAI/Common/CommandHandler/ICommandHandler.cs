using Common.Commands;
using Common.Models;
using MediatR;

namespace Common.CommandHandler
{
    public interface ICommandHandler : IRequestHandler<ICommand, EventStream>
    {
        public  Task<EventStream> HandleAsync(ICommand request, CancellationToken cancellationToken);
    }
}
