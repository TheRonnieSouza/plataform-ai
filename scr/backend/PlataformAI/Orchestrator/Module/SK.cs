using Microsoft.SemanticKernel;
using Orchestrator.Conversation;
using Orchestrator.Conversation.LLM;

namespace Orchestrator.Module
{
    public static class SK
    {
        public static IServiceCollection AddSemanticKernel(this IServiceCollection services, IConfiguration configuration)
        {
            IKernelBuilder? builder = Kernel.CreateBuilder();

            builder.Services.AddAzureOpenAIChatCompletion(
        configuration["LlmAzureOpenAI:DeploymentName"]!,
        configuration["LlmAzureOpenAI:Url"]!,
        configuration["LlmAzureOpenAI:Key"]!
    );

            Kernel kernel = builder.Build();
            services.AddSingleton(kernel);
            services.AddSingleton<IConversationCompletionService>(
                sp => new SemanticKernelCoversationCompletionService(sp.GetRequiredService<Kernel>())
            );
            services.AddTransient<SemanticKernelCoversationCompletionService>();


            return services;
        }
    }
}
