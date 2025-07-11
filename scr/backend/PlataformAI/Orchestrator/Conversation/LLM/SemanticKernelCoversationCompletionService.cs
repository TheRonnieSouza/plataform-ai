using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace Orchestrator.Conversation.LLM
{
    public class SemanticKernelCoversationCompletionService : IConversationCompletionService
    {
        private readonly Kernel _kernel;

        public SemanticKernelCoversationCompletionService(Kernel kernel)
        {
            _kernel = kernel;
        }

        public Task<Answer> AskAsync<Answer>(IEnumerable<string> contextMessages)
        {
            var  chatCompletionService = _kernel.GetRequiredService<IChatCompletionService>();

            string message = contextMessages.FirstOrDefault() ?? string.Empty;

            ChatHistory chatMessageContents = new ChatHistory(message, AuthorRole.System);

           var result = chatCompletionService.GetChatMessageContentAsync(chatMessageContents);

            return Task.FromResult<Answer>((Answer)(object)result.Result);
        }
    }
}
