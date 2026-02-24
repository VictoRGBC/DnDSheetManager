using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAttacksToDynamicCalc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttackBonus",
                table: "Attacks");

            migrationBuilder.DropColumn(
                name: "Properties",
                table: "Attacks");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinesse",
                table: "Attacks",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsProficient",
                table: "Attacks",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRanged",
                table: "Attacks",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinesse",
                table: "Attacks");

            migrationBuilder.DropColumn(
                name: "IsProficient",
                table: "Attacks");

            migrationBuilder.DropColumn(
                name: "IsRanged",
                table: "Attacks");

            migrationBuilder.AddColumn<int>(
                name: "AttackBonus",
                table: "Attacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Properties",
                table: "Attacks",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
