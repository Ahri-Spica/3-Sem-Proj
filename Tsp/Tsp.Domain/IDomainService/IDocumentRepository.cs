using System;
using System.Collections.Generic;
using System.Linq;
//using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Tsp.Domain.Models;

namespace Tsp.Domain.IDomainService
{
    public interface IDocumentRepository
    {
        Task<Document> GetDocumentById(int id);
        Task<IEnumerable<Document>> GetDocuments();
        Task<Document> AddDocument(Document document);
    }
}
