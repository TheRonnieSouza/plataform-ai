using Common.Commands;

namespace Orchestrator.Conversation.Ask
{
    public readonly record struct CreateMessageCommand(string message) : ICommand;
}
