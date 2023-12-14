using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tsp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Standard");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "MyProperty",
                newSchema: "Standard");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "MyProperty",
                schema: "Standard",
                newName: "MyProperty");
        }
    }
}
