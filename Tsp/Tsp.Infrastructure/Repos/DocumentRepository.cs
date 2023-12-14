using System;
using System.Collections.Generic;
using System.Linq;
//using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Tsp.Domain.IDomainService;
using Microsoft.EntityFrameworkCore;
using Tsp.Domain.Models;

namespace Tsp.Infrastructure.Repos
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly TspContext context;

        public DocumentRepository(TspContext _context)
        {
            context = _context;
        }

        async Task<Tsp.Domain.Models.Document> AddDocument(Domain.Models.Document document)
        {
            context.Documents.Add(document);
            await context.SaveChangesAsync();
            return document;
        }

        Task<Document> IDocumentRepository.AddDocument(Document document)
        {
            return AddDocument(document);
        }

        async Task<Tsp.Domain.Models.Document> GetDocumentById(int id)
        {
            return await context.Documents.FindAsync(id);
        }

        Task<Document> IDocumentRepository.GetDocumentById(int id)
        {
            return GetDocumentById(id);
        }

        async Task<IEnumerable<Tsp.Domain.Models.Document>> GetDocuments()
        {
            return await context.Documents.ToListAsync();
        }

        Task<IEnumerable<Document>> IDocumentRepository.GetDocuments()
        {
            return GetDocuments();
        }
    }
}
