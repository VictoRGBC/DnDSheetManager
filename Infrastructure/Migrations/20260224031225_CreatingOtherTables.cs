using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatingOtherTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AC_ArmorBonus",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AC_Base",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AC_DexterityModifierCap",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AC_MagicBonus",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AC_MiscBonus",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AC_ShieldBonus",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Alignment",
                table: "Characters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Background",
                table: "Characters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Bonds",
                table: "Characters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Conditions_Blinded",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Conditions_Charmed",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Conditions_Deafened",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Conditions_Exhaustion",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Conditions_ExhaustionLevel",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Conditions_Frightened",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Conditions_Grappled",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Conditions_Incapacitated",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Conditions_Invisible",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Conditions_Paralyzed",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Conditions_Petrified",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Conditions_Poisoned",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Conditions_Prone",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Conditions_Restrained",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Conditions_Stunned",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Conditions_Unconscious",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DamageResistances_Immunities",
                table: "Characters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DamageResistances_Resistances",
                table: "Characters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DamageResistances_Vulnerabilities",
                table: "Characters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ExperiencePoints",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Flaws",
                table: "Characters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "HasInspiration",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "HitDice",
                table: "Characters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "HitDiceUsed",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Ideals",
                table: "Characters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PersonalityTraits",
                table: "Characters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "SavingThrows_CharismaProficiency",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SavingThrows_ConstitutionProficiency",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SavingThrows_DexterityProficiency",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SavingThrows_IntelligenceProficiency",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SavingThrows_StrengthProficiency",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SavingThrows_WisdomProficiency",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_AcrobaticsExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_AnimalHandlingExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_ArcanaExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_AthleticsExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_DeceptionExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_HistoryExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_InsightExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_IntimidationExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_InvestigationExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_MedicineExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_NatureExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_PerceptionExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_PerformanceExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_PersuasionExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_ReligionExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_SleightOfHandExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_StealthExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skills_SurvivalExpertise",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Speed",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level1Total",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level1Used",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level2Total",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level2Used",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level3Total",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level3Used",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level4Total",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level4Used",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level5Total",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level5Used",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level6Total",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level6Used",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level7Total",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level7Used",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level8Total",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level8Used",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level9Total",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpellSlots_Level9Used",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Source = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsesPerRest = table.Column<int>(type: "int", nullable: true),
                    UsesRemaining = table.Column<int>(type: "int", nullable: true),
                    RestType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Features_CharacterId",
                table: "Features",
                column: "CharacterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropColumn(
                name: "AC_ArmorBonus",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "AC_Base",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "AC_DexterityModifierCap",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "AC_MagicBonus",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "AC_MiscBonus",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "AC_ShieldBonus",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Alignment",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Background",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Bonds",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Conditions_Blinded",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Conditions_Charmed",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Conditions_Deafened",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Conditions_Exhaustion",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Conditions_ExhaustionLevel",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Conditions_Frightened",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Conditions_Grappled",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Conditions_Incapacitated",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Conditions_Invisible",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Conditions_Paralyzed",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Conditions_Petrified",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Conditions_Poisoned",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Conditions_Prone",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Conditions_Restrained",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Conditions_Stunned",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Conditions_Unconscious",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "DamageResistances_Immunities",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "DamageResistances_Resistances",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "DamageResistances_Vulnerabilities",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ExperiencePoints",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Flaws",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "HasInspiration",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "HitDice",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "HitDiceUsed",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Ideals",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "PersonalityTraits",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SavingThrows_CharismaProficiency",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SavingThrows_ConstitutionProficiency",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SavingThrows_DexterityProficiency",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SavingThrows_IntelligenceProficiency",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SavingThrows_StrengthProficiency",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SavingThrows_WisdomProficiency",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_AcrobaticsExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_AnimalHandlingExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_ArcanaExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_AthleticsExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_DeceptionExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_HistoryExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_InsightExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_IntimidationExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_InvestigationExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_MedicineExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_NatureExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_PerceptionExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_PerformanceExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_PersuasionExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_ReligionExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_SleightOfHandExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_StealthExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skills_SurvivalExpertise",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level1Total",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level1Used",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level2Total",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level2Used",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level3Total",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level3Used",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level4Total",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level4Used",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level5Total",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level5Used",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level6Total",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level6Used",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level7Total",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level7Used",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level8Total",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level8Used",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level9Total",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SpellSlots_Level9Used",
                table: "Characters");
        }
    }
}
