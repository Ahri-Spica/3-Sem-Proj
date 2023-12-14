using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using static System.Net.Mime.MediaTypeNames;

namespace WebApp1.Data
{
    public class IdentityContext : IdentityDbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* var stringToLongTextConverter = new ValueConverter<string, string>(
                v => v,
                v => v);*/

            /* foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(string))
                    {
                        //property.SetValueConverter(stringToLongTextConverter);
                        property.SetColumnType("longtext");
                    }
                }
            }*/
             builder.Entity<IdentityUser>()
                .Property(x => x.ConcurrencyStamp)
                .HasColumnType("longtext");

            builder.Entity<IdentityRole>()
                .Property(x => x.ConcurrencyStamp)
                .HasColumnType("longtext");
        }
    }
}

