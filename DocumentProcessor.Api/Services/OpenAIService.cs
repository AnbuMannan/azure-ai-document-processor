using Azure.AI.OpenAI;
using DocumentProcessor.Api.Infrastructure;

namespace DocumentProcessor.Api.Services
{
    public class OpenAIService
    {
        private readonly OpenAIClient _client;
        private readonly string _model;

        public OpenAIService(AzureClients clients, IConfiguration config)
        {
            _client = clients.OpenAIClient;
            _model = config["AzureAI:OpenAIModel"]
                     ?? throw new ArgumentNullException("AzureAI:OpenAIModel");
        }

        public async Task<string> SummarizeAsync(string text)
        {
            var options = new ChatCompletionsOptions
            {
                DeploymentName = _model
            };

            options.Messages.Add(
                new ChatRequestSystemMessage(
                    "Summarize the invoice clearly and concisely.")
            );

            options.Messages.Add(
                new ChatRequestUserMessage(text)
            );

            var response = await _client.GetChatCompletionsAsync(options);

            return response.Value.Choices[0].Message.Content;
        }

    }
}
