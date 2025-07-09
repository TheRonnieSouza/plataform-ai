using Common.CommandHandler;
using Common.Commands;
using Common.Models;

namespace Orchestrator.Conversation.Ask
{
    public class CreateMessageCommandHandler : CommandHandler, ICommandHandler
    {
        public readonly IConversationCompletionService _chatCompletion;

        public CreateMessageCommandHandler(IConversationCompletionService chatCompletion)
        {
            _chatCompletion = chatCompletion; 
        }
    
        public  override  async Task<EventStream> HandleAsync(ICommand request, CancellationToken token)
        {          

           var command = GetCommand(request);

            var messages = new List<string>
             {
                 command.message
             };

            var result = await _chatCompletion.AskAsync(messages);

            var message = new EventStream(result.Content);

            return message;
        }

        private CreateMessageCommand GetCommand(ICommand request)
        {
            if (request is not CreateMessageCommand command)
                throw new ArgumentException("Invalid command type", nameof(request));
            return command;
        }
    }
}
