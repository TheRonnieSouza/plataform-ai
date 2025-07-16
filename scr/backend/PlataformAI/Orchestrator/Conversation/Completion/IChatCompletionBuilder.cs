using Microsoft.SemanticKernel.ChatCompletion;

namespace Orchestrator.Conversation.Completion
{
    public interface IChatCompletionBuilder
    {
        bool CanBuild(Message message);

        ChatHistory CreateChatHistory(Message message);
    }
}
