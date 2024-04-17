using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FullNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName_LastName",
                table: "passengers",
                newName: "PassLastName");

            migrationBuilder.RenameColumn(
                name: "FullName_FirstName",
                table: "passengers",
                newName: "PassFirstName");

            migrationBuilder.AlterColumn<string>(
                name: "PassFirstName",
                table: "passengers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassLastName",
                table: "passengers",
                newName: "FullName_LastName");

            migrationBuilder.RenameColumn(
                name: "PassFirstName",
                table: "passengers",
                newName: "FullName_FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "FullName_FirstName",
                table: "passengers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
