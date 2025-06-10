using Azure.AI.Inference;
using Orchestrator.Conversation.Factory;

namespace Orchestrator.Conversation
{
    public class ConversationCompletionService : IConversationCompletionService
    {
        public readonly ChatCompletionsClient _client;
        private readonly ChatCompletionsOptionsFactory _optionsFactory;

        public ConversationCompletionService(ChatCompletionsClient client, ChatCompletionsOptionsFactory completionFactory)
        {
            _client = client;
            _optionsFactory = completionFactory;
        }

        public async Task<ChatCompletions> AskAsync(IEnumerable<string> contextMessages)
        {

            var options = _optionsFactory(contextMessages);

            var response = await _client.CompleteAsync(options);

            return response;
        }
    }

    public interface IConversationCompletionService
    {
        Task<ChatCompletions> AskAsync(IEnumerable<string> contextMessages);
    }
}
