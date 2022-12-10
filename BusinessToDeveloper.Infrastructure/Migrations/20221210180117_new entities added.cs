using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessToDeveloper.Infrastructure.Migrations
{
    public partial class newentitiesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_BusinessId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "ForeignKey_DeveloperId",
                table: "Projects");

            migrationBuilder.DropUniqueConstraint(
                name: "AlternateKey_Name",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_BusinessId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_DeveloperId",
                table: "Projects");

            migrationBuilder.DropUniqueConstraint(
                name: "AlternateKey_Developer_Email",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Developers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projects",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Developers",
                newName: "DeveloperId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.CreateTable(
                name: "Expertises",
                columns: table => new
                {
                    ExpertiseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expertises", x => x.ExpertiseId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessExpertises",
                columns: table => new
                {
                    BusinessExpertiseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    ExpertiseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessExpertises", x => x.BusinessExpertiseId);
                    table.ForeignKey(
                        name: "FK_BusinessExpertises_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessExpertises_Expertises_ExpertiseId",
                        column: x => x.ExpertiseId,
                        principalTable: "Expertises",
                        principalColumn: "ExpertiseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperExpertises",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    ExpertiseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperExpertises", x => new { x.DeveloperId, x.ExpertiseId });
                    table.ForeignKey(
                        name: "FK_DeveloperExpertises_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "DeveloperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperExpertises_Expertises_ExpertiseId",
                        column: x => x.ExpertiseId,
                        principalTable: "Expertises",
                        principalColumn: "ExpertiseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessSkills",
                columns: table => new
                {
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessSkills", x => new { x.BusinessId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_BusinessSkills_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperSkills",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperSkills", x => new { x.DeveloperId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_DeveloperSkills_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "DeveloperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_BusinessId",
                table: "Projects",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DeveloperId",
                table: "Projects",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessExpertises_BusinessId",
                table: "BusinessExpertises",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessExpertises_ExpertiseId",
                table: "BusinessExpertises",
                column: "ExpertiseId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessSkills_SkillId",
                table: "BusinessSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperExpertises_ExpertiseId",
                table: "DeveloperExpertises",
                column: "ExpertiseId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperSkills_SkillId",
                table: "DeveloperSkills",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Businesses_BusinessId",
                table: "Projects",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Developers_DeveloperId",
                table: "Projects",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "DeveloperId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Businesses_BusinessId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Developers_DeveloperId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "BusinessExpertises");

            migrationBuilder.DropTable(
                name: "BusinessSkills");

            migrationBuilder.DropTable(
                name: "DeveloperExpertises");

            migrationBuilder.DropTable(
                name: "DeveloperSkills");

            migrationBuilder.DropTable(
                name: "Expertises");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Projects_BusinessId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_DeveloperId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Projects",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DeveloperId",
                table: "Developers",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AlternateKey_Name",
                table: "Projects",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AlternateKey_Developer_Email",
                table: "Developers",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_BusinessId",
                table: "Projects",
                column: "BusinessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DeveloperId",
                table: "Projects",
                column: "DeveloperId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_BusinessId",
                table: "Projects",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_DeveloperId",
                table: "Projects",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
