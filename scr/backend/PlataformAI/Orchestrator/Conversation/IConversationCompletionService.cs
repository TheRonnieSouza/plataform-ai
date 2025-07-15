namespace Orchestrator.Conversation
{
    public interface IConversationCompletionService
    {
        /// <summary>
        /// Asks a question or sends a message to the conversation service and returns the response.
        /// </summary>
        /// <typeparam name="T">The type of the response expected.</typeparam>
        /// <param name="contextMessages">A collection of context messages to include in the request.</param>
        /// <returns>A task that represents the asynchronous operation, containing the response of type T.</returns>
    
        Task<T> AskAsync<T>(Message message);
    }
}