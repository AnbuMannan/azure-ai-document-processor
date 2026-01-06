using Microsoft.AspNetCore.Mvc;
using DocumentProcessor.Api.Services;

namespace DocumentProcessor.Api.Controllers
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentsController : ControllerBase
    {
        private readonly DocumentIntelligenceService _docService;
        private readonly OpenAIService _openAI;
        private readonly VectorSearchService _search;

        public DocumentsController(
            DocumentIntelligenceService docService,
            OpenAIService openAI,
            VectorSearchService search)
        {
            _docService = docService;
            _openAI = openAI;
            _search = search;
        }

        [HttpPost("process")]
        public async Task<IActionResult> Process(IFormFile file)
        {
            using var stream = file.OpenReadStream();

            var extractedText = await _docService.ExtractTextAsync(stream);
            var summary = await _openAI.SummarizeAsync(extractedText);

            await _search.IndexAsync(Guid.NewGuid().ToString(), extractedText);

            return Ok(new { Summary = summary });
        }
    }
}
