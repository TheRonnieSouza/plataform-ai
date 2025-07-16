using Azure.AI.Inference;
using Orchestrator.Conversation.Mensagens;

namespace Orchestrator.Conversation.Factory
{
    public delegate ChatCompletionsOptions ChatCompletionsOptionsFactory(Message messages);    
}
