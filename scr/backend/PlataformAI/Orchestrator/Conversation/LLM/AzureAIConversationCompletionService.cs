using Azure.AI.Inference;
using Orchestrator.Conversation.Factory;

namespace Orchestrator.Conversation.LLM
{
    public class AzureAIConversationCompletionService : IConversationCompletionService
    {
        public readonly ChatCompletionsClient _client;
        private readonly ChatCompletionsOptionsFactory _optionsFactory;

        public AzureAIConversationCompletionService(ChatCompletionsClient client, ChatCompletionsOptionsFactory completionFactory)
        {
            _client = client;
            _optionsFactory = completionFactory;
        }

        public async Task<ChatCompletions> AskAsync<ChatCompletions>(IEnumerable<string> contextMessages)
        {
            var options = _optionsFactory(contextMessages);

            var response = await _client.CompleteAsync(options);


            return response.Value is ChatCompletions result ? result : throw new InvalidCastException($"Cannot cast ChatCompletions to type {typeof(ChatCompletions).Name}");
        }        
    }
  
}
