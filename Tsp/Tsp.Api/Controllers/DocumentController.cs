using Microsoft.AspNetCore.Mvc;
using Tsp.Domain.IDomainService;
using Tsp.Domain.Models;

namespace Tsp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository documentRepository;

        public DocumentController(IDocumentRepository _documentRepository)
        {
            documentRepository = _documentRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Document>> AddDocument([FromBody]Document document)
        {
            await documentRepository.AddDocument(document);
            return CreatedAtAction(nameof(GetDocument), new {id = document.Id}, document);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Document>> GetDocument(int id)
        {
            var document = await documentRepository.GetDocumentById(id);
            if (document == null)
            {
                return NotFound();
            }
            return document;
        }
    }
}
