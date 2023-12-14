using Microsoft.EntityFrameworkCore;
using Tsp.Domain.IDomainService;
using Tsp.Infrastructure;
using Tsp.Infrastructure.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TspContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostGresDB"), 
    x =>
    {
        x.MigrationsAssembly("Tsp.Infrastructure");
    }));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehaviour", true);
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
