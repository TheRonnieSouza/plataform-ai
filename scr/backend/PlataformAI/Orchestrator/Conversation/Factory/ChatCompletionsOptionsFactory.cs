using Azure.AI.Inference;

namespace Orchestrator.Conversation.Factory
{
    public delegate ChatCompletionsOptions ChatCompletionsOptionsFactory(IEnumerable<string> messages);    
}
