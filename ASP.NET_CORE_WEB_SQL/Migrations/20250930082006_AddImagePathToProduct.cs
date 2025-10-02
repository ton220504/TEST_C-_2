using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_CORE_WEB_SQL.Migrations
{
    /// <inheritdoc />
    public partial class AddImagePathToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.AddColumn<string>(
             name: "ImagePath",
             table: "Test_Product",
             type: "nvarchar(max)",
             nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test_Product");
        }
    }
}
