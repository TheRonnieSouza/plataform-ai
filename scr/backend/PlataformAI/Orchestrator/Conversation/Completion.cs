using Azure.AI.Inference;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace Orchestrator.Conversation
{
    public class Completion : IConversationCompletionService
    {
        private readonly Kernel _kernel;
        public IReadOnlyDictionary<string, object?> Attributes => throw new NotImplementedException();

        public Task<ChatCompletions> AskAsync(IEnumerable<string> contextMessages)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<ChatMessageContent>> GetChatMessageContentsAsync(ChatHistory chatHistory, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<StreamingChatMessageContent> GetStreamingChatMessageContentsAsync(ChatHistory chatHistory, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
