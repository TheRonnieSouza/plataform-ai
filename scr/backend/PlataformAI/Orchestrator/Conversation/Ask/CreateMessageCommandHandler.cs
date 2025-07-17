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
            var command = (CreateMessageCommand)request;

            var result = await _chatCompletion.AskAsync<EventStream>(command.Message);

            var message = new EventStream(result.Content);

            return message;
        }

    }
}
