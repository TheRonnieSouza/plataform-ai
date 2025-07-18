using Common.Commands;
using Orchestrator.Conversation.Mensagens;

namespace Orchestrator.Conversation.Ask
{
    public class CreateMessageCommand : ICommand
    {
        public Message Message { get; set; } = default!;
    }
}
