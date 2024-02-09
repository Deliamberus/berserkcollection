using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerserkCollection.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCardCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Cards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Cards",
                type: "int",
                nullable: true);
        }
    }
}
