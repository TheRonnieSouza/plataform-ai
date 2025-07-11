using Common.CommandHandler;
using Common.Commands;
using Common.Models;
using Orchestrator.Conversation.Factory;

namespace Orchestrator.Conversation.Ask
{
    public class CreateMessageCommandHandler : CommandHandler, ICommandHandler
    {
        public readonly IConversationCompletionService _chatCompletion;

        public CreateMessageCommandHandler(IConversationCompletionFactory chatCompletionFactory)
        {
            _chatCompletion = chatCompletionFactory.Create();
        }

        public override async Task<EventStream> HandleAsync(ICommand request, CancellationToken token)
        {
            var command = GetCommand(request);

            var messages = new List<string>
                {
                    command.message
                };

            var result = await _chatCompletion.AskAsync<EventStream>(messages);

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
