using Orchestrator.Conversation.LLM;

namespace Orchestrator.Conversation.Factory
{
    public class ConversationCompletionFactory: IConversationCompletionFactory
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _provider;

        public ConversationCompletionFactory(IConfiguration configuration, IServiceProvider provider)
        {
            _configuration = configuration;
            _provider = provider;
        }

        public IConversationCompletionService Create()
        {
            string provider = _configuration["LlmProvider:Provider"]!; 

            switch (provider)
            {
                case "AzureAIInference":
                    return _provider.GetService< AzureAIConversationCompletionService>()!;
                case "AzureOpenAI":
                    return _provider.GetService< SemanticKernelCoversationCompletionService>()!;
                default:
                    throw new NotSupportedException($"The provider '{provider}' is not supported.");
            }


        }
    }
}
