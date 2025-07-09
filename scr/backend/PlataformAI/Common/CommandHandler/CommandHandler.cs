using Common.Commands;
using Common.Models;

namespace Common.CommandHandler
{
    public abstract class CommandHandler : ICommandHandler
    {        
        public CommandHandler() { }
        public async  Task<EventStream> Handle(ICommand request, CancellationToken cancellationToken)
        {
            var result = await HandleAsync(request, cancellationToken);
            if (result != null)
                return result;

            return result;
        }

        public abstract Task<EventStream> HandleAsync(ICommand request, CancellationToken token);

       
    }
}
