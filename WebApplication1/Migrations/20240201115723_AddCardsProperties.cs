using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerserkCollection.Migrations
{
    /// <inheritdoc />
    public partial class AddCardsProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Armor",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExpAtack",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExpDef",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExpShot",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefFly",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefMagic",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefPoison",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefShot",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefSpell",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefStrike",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefThrow",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHorde",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStamina",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTarget",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Regen",
                table: "Cards",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Armor",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ExpAtack",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ExpDef",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ExpShot",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IsDefFly",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IsDefMagic",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IsDefPoison",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IsDefShot",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IsDefSpell",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IsDefStrike",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IsDefThrow",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IsHorde",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IsStamina",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IsTarget",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Regen",
                table: "Cards");
        }
    }
}
