using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultancy.Data.Migrations
{
    public partial class AddIdForConsultantMission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsultantMissions",
                table: "ConsultantMissions");

            migrationBuilder.DeleteData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ConsultantMissions",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsultantMissions",
                table: "ConsultantMissions",
                column: "Id");

            migrationBuilder.InsertData(
                table: "ConsultantMissions",
                columns: new[] { "Id", "ConsultantId", "JobName", "MissionId", "Rate", "isActive" },
                values: new object[,]
                {
                    { 1, 1, "Dev", 3, 400.0, true },
                    { 2, 2, "Consultant", 1, 400.0, true },
                    { 3, 2, "Dev", 3, 400.0, false },
                    { 4, 3, "Dev", 2, 400.0, false },
                    { 5, 3, "Dev", 3, 500.0, true },
                    { 6, 3, "Dev", 1, 400.0, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantMissions_ConsultantId",
                table: "ConsultantMissions",
                column: "ConsultantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsultantMissions",
                table: "ConsultantMissions");

            migrationBuilder.DropIndex(
                name: "IX_ConsultantMissions_ConsultantId",
                table: "ConsultantMissions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ConsultantMissions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsultantMissions",
                table: "ConsultantMissions",
                columns: new[] { "ConsultantId", "MissionId" });
        }
    }
}
