using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.Samples.Migrations
{
    public partial class adedCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentBase",
                table: "CatalogEntities",
                newName: "ParentCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentCode",
                table: "CatalogEntities",
                newName: "ParentBase");
        }
    }
}
