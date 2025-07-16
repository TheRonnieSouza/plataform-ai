using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace Orchestrator.Conversation.Completion
{
    public class ImageMessage : IChatCompletionBuilder
    {
        //Todo Implent
        public bool CanBuild(Message message)
        {
            throw new NotImplementedException();
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
