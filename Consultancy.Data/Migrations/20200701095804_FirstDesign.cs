using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultancy.Data.Migrations
{
    public partial class FirstDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Experience = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MaximumRate = table.Column<int>(nullable: false),
                    ExperienceRequired = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsultantMissions",
                columns: table => new
                {
                    ConsultantId = table.Column<int>(nullable: false),
                    MissionId = table.Column<int>(nullable: false),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultantMissions", x => new { x.ConsultantId, x.MissionId });
                    table.ForeignKey(
                        name: "FK_ConsultantMissions_Consultants_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultantMissions_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Consultants",
                columns: new[] { "Id", "Experience", "Firstname", "Lastname" },
                values: new object[,]
                {
                    { 1, 0, "Jawad", "Chemlal" },
                    { 2, 1, "Xavier", "Piekara" },
                    { 3, 2, "Loic", "Ramelot" }
                });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "ExperienceRequired", "MaximumRate", "Name" },
                values: new object[,]
                {
                    { 1, 1, 500, "Google" },
                    { 2, 2, 700, "Amazon" },
                    { 3, 0, 400, "NRB" }
                });

            migrationBuilder.InsertData(
                table: "ConsultantMissions",
                columns: new[] { "ConsultantId", "MissionId", "isActive" },
                values: new object[,]
                {
                    { 2, 1, true },
                    { 3, 1, false },
                    { 3, 2, true },
                    { 1, 3, true },
                    { 2, 3, false },
                    { 3, 3, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantMissions_MissionId",
                table: "ConsultantMissions",
                column: "MissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultantMissions");

            migrationBuilder.DropTable(
                name: "Consultants");

            migrationBuilder.DropTable(
                name: "Missions");
        }
    }
}
