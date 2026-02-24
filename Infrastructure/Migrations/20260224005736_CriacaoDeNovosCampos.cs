using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDeNovosCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Wisdom",
                table: "Characters",
                newName: "Abilities_Wisdom");

            migrationBuilder.RenameColumn(
                name: "Strength",
                table: "Characters",
                newName: "Abilities_Strength");

            migrationBuilder.RenameColumn(
                name: "Intelligence",
                table: "Characters",
                newName: "Abilities_Intelligence");

            migrationBuilder.RenameColumn(
                name: "Dexterity",
                table: "Characters",
                newName: "Abilities_Dexterity");

            migrationBuilder.RenameColumn(
                name: "Constitution",
                table: "Characters",
                newName: "Abilities_Constitution");

            migrationBuilder.RenameColumn(
                name: "Charisma",
                table: "Characters",
                newName: "Abilities_Charisma");

            migrationBuilder.RenameColumn(
                name: "Race",
                table: "Characters",
                newName: "Species");

            migrationBuilder.AddColumn<bool>(
                name: "Skills_Acrobatics",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_AnimalHandling",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_Arcana",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_Athletics",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_Deception",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_History",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_Insight",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_Intimidation",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_Investigation",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_Medicine",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_Nature",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_Perception",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_Performance",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_Persuasion",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_Religion",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_SleightOfHand",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_Stealth",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_Survival",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Wealth_CopperPieces",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wealth_ElectrumPieces",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wealth_GoldPieces",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wealth_PlatinumPieces",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wealth_SilverPieces",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Skills_Acrobatics",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_AnimalHandling",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_Arcana",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_Athletics",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_Deception",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_History",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_Insight",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_Intimidation",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_Investigation",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_Medicine",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_Nature",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_Perception",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_Performance",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_Persuasion",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_Religion",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_SleightOfHand",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_Stealth",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_Survival",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Wealth_CopperPieces",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Wealth_ElectrumPieces",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Wealth_GoldPieces",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Wealth_PlatinumPieces",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Wealth_SilverPieces",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "Abilities_Wisdom",
                table: "Characters",
                newName: "Wisdom");

            migrationBuilder.RenameColumn(
                name: "Abilities_Strength",
                table: "Characters",
                newName: "Strength");

            migrationBuilder.RenameColumn(
                name: "Abilities_Intelligence",
                table: "Characters",
                newName: "Intelligence");

            migrationBuilder.RenameColumn(
                name: "Abilities_Dexterity",
                table: "Characters",
                newName: "Dexterity");

            migrationBuilder.RenameColumn(
                name: "Abilities_Constitution",
                table: "Characters",
                newName: "Constitution");

            migrationBuilder.RenameColumn(
                name: "Abilities_Charisma",
                table: "Characters",
                newName: "Charisma");

            migrationBuilder.RenameColumn(
                name: "Species",
                table: "Characters",
                newName: "Race");
        }
    }
}
