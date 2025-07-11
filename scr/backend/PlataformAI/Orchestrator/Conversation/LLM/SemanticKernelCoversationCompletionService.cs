using Common.Models;
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


        public async Task<T> AskAsync<T>(IEnumerable<string> contextMessages)
        {
            var  chatCompletionService = _kernel.GetRequiredService<IChatCompletionService>();

            string message = contextMessages.FirstOrDefault() ?? string.Empty;

            ChatHistory chatMessageContents = new ChatHistory(message, AuthorRole.System);

            var result = await chatCompletionService.GetChatMessageContentAsync(chatMessageContents);
            
            var evento =   new EventStream(result);
            return (T)(object)evento;


        }
    }
}
