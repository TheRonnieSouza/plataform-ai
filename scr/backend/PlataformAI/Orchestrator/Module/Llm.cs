using Azure;
using Azure.AI.Inference;
using Microsoft.SemanticKernel;
using Orchestrator.Conversation;
using Orchestrator.Conversation.Factory;
using Orchestrator.Conversation.LLM;

namespace Orchestrator.Module
{
    public static class Llm
    {
        public static IServiceCollection AddLlm(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAzureAIInference(configuration).
                AddSemanticKernel(configuration);

            return services;
        }

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
                     

            return services;
        }

        private static IServiceCollection AddAzureAIInference(this IServiceCollection services, IConfiguration configuration)
        {
            var (endpoint, credential) = GetLlmSettings(configuration);
            services.AddScoped(_ => new ChatCompletionsClient(endpoint, credential));

            services.AddScoped<ChatCompletionsOptionsFactory>(sp =>
            {

                return messages =>
                {
                    var options = new ChatCompletionsOptions
                    {
                        Model = configuration["Llm:Model"],
                        Temperature = 0.8f,
                        MaxTokens = 2048
                    };

                    foreach (var msg in messages)
                    {
                        options.Messages.Add(new ChatRequestUserMessage(msg));
                    }

                    return options;
                };
            });

            services.AddScoped<IConversationCompletionService, AzureAIConversationCompletionService>();

            return services;
        }
        private static (Uri endpoint, AzureKeyCredential credential) GetLlmSettings(IConfiguration configuration)
        {
            var key = configuration["Llm:Key"];
            var endpoint = configuration["Llm:BaseUrl"];

            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(endpoint))
                throw new InvalidOperationException("Llm configuration is missing.");

            return (new Uri(endpoint), new AzureKeyCredential(key));
        }
    }
}
