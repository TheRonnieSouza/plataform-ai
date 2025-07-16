using Common.Models;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Orchestrator.Conversation.Completion;
using System.Reflection.Metadata.Ecma335;

namespace Orchestrator.Conversation.LLM
{
    public class SemanticKernelCoversationCompletionService : IConversationCompletionService
    {
        private readonly Kernel _kernel;

        public SemanticKernelCoversationCompletionService(Kernel kernel)
        {
            _kernel = kernel;
        }


        public async Task<T> AskAsync<T>(Message message)
        {
            var chatMessageContents = new ChatHistory();

            var chatCompletionService = _kernel.GetRequiredService<IChatCompletionService>();
                        
            var builder = new List<IChatCompletionBuilder>
            {
                new ImageMessage(),
                new ChatMessage(),
            };

            foreach(var build in builder)
            {
                chatMessageContents = build.CanBuild(message) ? build.CreateChatHistory(message) : chatMessageContents;
            }            

            var result = await chatCompletionService.GetChatMessageContentAsync(chatMessageContents);
            
            var evento =   new EventStream(result);
            return (T)(object)evento;
        }
    }
}
