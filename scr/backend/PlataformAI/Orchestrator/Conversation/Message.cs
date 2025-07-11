using Common.Models;

namespace Orchestrator.Conversation
{
    public class Message : AggregateRoot
    {
        string Question { get; set; }
        string Answer { get; set; }

    }
}
