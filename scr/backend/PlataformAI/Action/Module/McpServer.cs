using ModelContextProtocol;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using System.Text.Json;

namespace Action.Module
{
    public static class McpServer
    {
        public static IServiceCollection AddMcp(this IServiceCollection services)
        {


            services.AddMcpServer(CreateOptions())
                    .WithStdioServerTransport()
                    .WithToolsFromAssembly();

            return services;
        }

        private static Action<McpServerOptions>? CreateOptions() =>
    options =>
         {
             options.ServerInfo = new Implementation { Name = "ActionServer", Version = "1.0.0" };
             options.Capabilities = new ServerCapabilities
             {
                 Tools = new ToolsCapability
                 {
                     ListToolsHandler = (req, ct) => ValueTask.FromResult(new ListToolsResult
                     {
                         // **observação:** inicializar lista assim:
                         Tools = new List<Tool>
                         {
                             new Tool
                             {
                                 Name = "echo",
                                 Description = "Echoes the input back to the client.",
                                 InputSchema = JsonSerializer.Deserialize<JsonElement>(@"
                                 {
                                     ""type"": ""object"",
                                     ""properties"": {
                                       ""message"": {
                                         ""type"": ""string"",
                                         ""description"": ""The input to echo back""
                                       }
                                     },
                                     ""required"": [""message""]
                                 }")
                             }
                         }
                     }),
                     CallToolHandler = (req, ct) =>
                     {
                         if (req.Params?.Name == "echo" &&
                             req.Params.Arguments?.TryGetValue("message", out var msg) == true)
                         {
                             return ValueTask.FromResult(new CallToolResult
                             {
                                 Content = new[]
                                 {
                                     new TextContentBlock { Text = $"Echo: {msg}", Type = "text" }
                                 }
                             });
                         }
                         throw new McpException($"Unknown tool: '{req.Params?.Name}'");
                     }
                 }
             };
         };
    }
}

