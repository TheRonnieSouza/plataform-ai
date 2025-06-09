using Common.CommandHandler;
using Common.Commands;
using Microsoft.SemanticKernel.ChatCompletion;
using Orchestrator.Conversation.Ask;

namespace Orchestrator.Module
{
    public static class Orchestrator
    {
        public static IServiceCollection AddOrchestratorModule(this IServiceCollection services)
        {
            services.AddSemanticKernel().
                     AddConversation();

            return services;
        }

        private static IServiceCollection AddSemanticKernel(this IServiceCollection services)
        {
            services.AddScoped<IChatCompletionService>();
            return services;
        }

        private static IServiceCollection AddConversation(this IServiceCollection services)
        {
            services.AddTransient<CreateMessageCommandHandler>();

            return services;
        }
    }
}
