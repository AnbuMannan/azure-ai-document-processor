# Azure AI Document Processor

AI-powered document processing system built using .NET 8 and Azure AI services.

## Features
- Invoice OCR using Azure Document Intelligence
- Natural language summaries using Azure OpenAI
- Semantic search using Azure Cognitive Search
- Clean API-first architecture

## Tech Stack
- .NET 8 Web API
- Azure OpenAI
- Azure AI Document Intelligence
- Azure Cognitive Search
- Azure Blob Storage

## Why This Project
Demonstrates real-world AI consumption patterns aligned with Microsoft AI-102,
focusing on integration, security, and scalability rather than model training.

## Getting Started

1. Clone the repository
2. Configure Azure AI services in appsettings.json
3. Run:
   dotnet restore
   dotnet build
   dotnet run

## API Endpoint

POST /api/documents/process  
Accepts PDF or image file and returns AI-generated summary.
