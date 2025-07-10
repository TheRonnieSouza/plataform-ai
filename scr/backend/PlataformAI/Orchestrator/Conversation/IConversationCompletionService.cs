namespace Orchestrator.Conversation
{
    public interface IConversationCompletionService
    {
        Task<T> AskAsync<T>(IEnumerable<string> contextMessages);
    }
}