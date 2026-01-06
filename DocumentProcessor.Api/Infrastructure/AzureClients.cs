using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using Azure.AI.OpenAI;
using Azure.Search.Documents;

namespace DocumentProcessor.Api.Infrastructure
{
    public class AzureClients
    {
        public DocumentAnalysisClient DocumentClient { get; }
        public OpenAIClient OpenAIClient { get; }
        public SearchClient SearchClient { get; }

        public AzureClients(IConfiguration config)
        {
            DocumentClient = new DocumentAnalysisClient(
                new Uri(config["AzureAI:DocumentIntelligenceEndpoint"]),
                new AzureKeyCredential(config["AzureAI:DocumentIntelligenceKey"])
            );

            OpenAIClient = new OpenAIClient(
                new Uri(config["AzureAI:OpenAIEndpoint"]),
                new AzureKeyCredential(config["AzureAI:OpenAIKey"])
            );

            SearchClient = new SearchClient(
                new Uri(config["AzureAI:SearchEndpoint"]),
                config["AzureAI:SearchIndex"],
                new AzureKeyCredential(config["AzureAI:SearchKey"])
            );
        }
    }
}
