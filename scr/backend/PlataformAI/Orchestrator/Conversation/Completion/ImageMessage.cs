using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Orchestrator.Conversation.Mensagens;

namespace Orchestrator.Conversation.Completion
{
    public class ImageMessage : IChatCompletionBuilder
    {        
        public bool CanBuild(Message message)
        {
            return message.Files.Count() > 0;
        }

        public ChatHistory CreateChatHistory(Message message)
        {
            var chatHistory = new ChatHistory(message.Question);

            foreach (var file in message.GetFilesBytes())
            {
                chatHistory.AddUserMessage(new ChatMessageContentItemCollection()
                {
                    new ImageContent(file.Data, file.ContentType)
                });
            }
            return chatHistory;
        }
    }
}
