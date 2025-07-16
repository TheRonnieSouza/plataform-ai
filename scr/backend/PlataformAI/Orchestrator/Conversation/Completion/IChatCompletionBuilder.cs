using Microsoft.SemanticKernel.ChatCompletion;
using Orchestrator.Conversation.Mensagens;

namespace Orchestrator.Conversation.Completion
{
    public interface IChatCompletionBuilder
    {
        bool CanBuild(Message message);

        ChatHistory CreateChatHistory(Message message);
    }
}
