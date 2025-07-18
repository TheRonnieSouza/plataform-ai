using Microsoft.SemanticKernel;
using Orchestrator.Conversation;
using Orchestrator.Conversation.Ask;
using Orchestrator.Conversation.Factory;
using Orchestrator.Conversation.LLM;

namespace Orchestrator.Module
{
    public static class Orchestrator
    {
        public static IServiceCollection AddOrchestratorModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLlm(configuration).
                     AddConversation();                     

            return services;
        }
        private static IServiceCollection AddConversation(this IServiceCollection services)
        {
            services.AddTransient<CreateMessageCommandHandler>();
            services.AddTransient<AzureAIConversationCompletionService>();
            services.AddTransient<IConversationCompletionFactory, ConversationCompletionFactory>();
            services.AddTransient<SemanticKernelCoversationCompletionService>();
            services.AddTransient<IConversationCompletionService>(
               sp => new SemanticKernelCoversationCompletionService(sp.GetRequiredService<Kernel>())
           );
            return services;
        }
    }
}
