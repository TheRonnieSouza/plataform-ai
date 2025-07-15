using Common.Commands;

namespace Orchestrator.Conversation.Ask
{
    public readonly record struct CreateMessageCommand(Message message) : ICommand;
}
