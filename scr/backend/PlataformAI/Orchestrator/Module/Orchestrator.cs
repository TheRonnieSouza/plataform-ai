using Azure;
using Azure.AI.Inference;
using Orchestrator.Conversation;
using Orchestrator.Conversation.Ask;
using Orchestrator.Conversation.Factory;

namespace Orchestrator.Module
{
    public static class Orchestrator
    {
        public static IServiceCollection AddOrchestratorModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSemanticKernel(configuration).
                     AddConversation();

            return services;
        }

        private static IServiceCollection AddSemanticKernel(this IServiceCollection services, IConfiguration configuration)
        {
            var (endpoint, credential ) = GetLlmSettings(configuration);
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

            services.AddScoped<IConversationCompletionService, ConversationCompletionService>();

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

        private static IServiceCollection AddConversation(this IServiceCollection services)
        {
            services.AddTransient<CreateMessageCommandHandler>();

            return services;
        }
    }
}
