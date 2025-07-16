using Microsoft.SemanticKernel.ChatCompletion;
using Orchestrator.Conversation.Mensagens;

namespace Orchestrator.Conversation.Completion
{
    public class ChatMessage : IChatCompletionBuilder
    {
        public bool CanBuild(Message message)
        {
            return message.Files.Count == 0 && string.IsNullOrEmpty(message.Question) ;
        }

        public ChatHistory CreateChatHistory(Message message)
        {
            return new ChatHistory(message.Question);
        }
    }
}
