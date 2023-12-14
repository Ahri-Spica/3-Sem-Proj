using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Tsp.Domain.Models;
//TODO consider the use of DTOs instead

namespace Tsp.Infrastructure;

public class TspContext : DbContext
{
    public TspContext(DbContextOptions<TspContext> options) : base(options)
    {

    }

    public DbSet<Document> Documents { get; set; }
}