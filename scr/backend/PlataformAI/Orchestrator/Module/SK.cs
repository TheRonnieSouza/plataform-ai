using Microsoft.SemanticKernel;

namespace Orchestrator.Module
{
    public static class SK
    {
        public static IServiceCollection AddSemanticKernel(this IServiceCollection services, IConfiguration configuration)
        {
            var deploymentName = "";
            var endpoint = "";
            var apiKey = "";

            IKernelBuilder? builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(deploymentName, endpoint, apiKey);

            builder.Services.AddAzureOpenAIChatCompletion(
                configuration["LlmAzureOpenAI:DeploymentName"]!,
                configuration["LlmAzureOpenAI:Url"]!,
                configuration["LlmAzureOpenAI:Key"]!);

            return services;
        }
    }
}
