using Azure.AI.Inference;
using Orchestrator.Conversation.Factory;
using Orchestrator.Conversation.Mensagens;

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

        public async Task<ChatCompletions> AskAsync<ChatCompletions>(Message message)
        {
            var options = _optionsFactory(message);

            var response = await _client.CompleteAsync(options);


            return response.Value is ChatCompletions result ? result : throw new InvalidCastException($"Cannot cast ChatCompletions to type {typeof(ChatCompletions).Name}");
        }        
    }
  
}
