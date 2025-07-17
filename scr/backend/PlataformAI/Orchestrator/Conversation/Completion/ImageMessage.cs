using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Orchestrator.Conversation.Mensagens;

namespace Orchestrator.Conversation.Completion
{
    public class ImageMessage : IChatCompletionBuilder
    {        
        public bool CanBuild(Message message)
        {            
            return message.Files == null ? false : message.Files!.Any();
        }

        public ChatHistory CreateChatHistory(Message message)
        {
            var chatHistory = new ChatHistory(message.Question);

            foreach (var file in message.GetFilesBytes())
            {
                chatHistory.AddMessage(AuthorRole.User, new ChatMessageContentItemCollection()
                {
                    new ImageContent(file.Data, file.ContentType)
                });
            }
            return chatHistory;
        }
    }
}
