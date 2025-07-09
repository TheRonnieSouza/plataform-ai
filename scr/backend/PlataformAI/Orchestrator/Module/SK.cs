using Microsoft.SemanticKernel;

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
                configuration["LlmAzureOpenAI:Key"]!);

            Kernel kernel = builder.Build();

            services.AddSingleton(kernel);

            return services;
        }
    }
}
