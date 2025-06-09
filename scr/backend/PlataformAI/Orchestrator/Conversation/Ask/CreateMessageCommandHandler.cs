using Common.CommandHandler;
using Common.Commands;
using Common.Models;

namespace Orchestrator.Conversation.Ask
{
    public class CreateMessageCommandHandler : CommandHandler, ICommandHandler
    {
        public readonly ISKService _skService;

        public CreateMessageCommandHandler(ISKService skService)
        {
            _skService = skService; 
        }
    
        public  override  Task<EventStream> HandleAsync(ICommand request, CancellationToken token)
        {
             var Aswer =  _skService.GetChatCompletion(request);

            var intention = _skService.GetIntention(Aswer);



            var message = new EventStream();

            return Task.FromResult(message);
        }
    }
}
