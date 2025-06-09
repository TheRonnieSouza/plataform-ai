using Common.Commands;
using Microsoft.SemanticKernel.ChatCompletion;

namespace Orchestrator.Conversation
{
    public class SKService : ISKService
    {
        public readonly IChatCompletionService _chatService;

        public SKService(IChatCompletionService service)
        {
            _chatService = service;
        }

        public object GetChatCompletion(ICommand message)
        {
            throw new NotImplementedException();
        }

        public object GetIntention(object message)
        {
            throw new NotImplementedException();
        }
    }

    public interface ISKService
    {
        public object GetChatCompletion (ICommand command);

        public object GetIntention(object command);
    }
}
