using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "passengers",
                newName: "FullName_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "passengers",
                newName: "FullName_FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName_LastName",
                table: "passengers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FullName_FirstName",
                table: "passengers",
                newName: "FirstName");
        }
    }
}
