using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bjay.Api.Repositories.Implementation.Migrations
{
    /// <inheritdoc />
    public partial class AddActivityMetadata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "Activities",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meta",
                table: "Activities");
        }
    }
}
