using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultancy.Data.Migrations
{
    public partial class AddJobName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobName",
                table: "ConsultantMissions",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 1, 3 },
                column: "JobName",
                value: "Dev");

            migrationBuilder.UpdateData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 2, 1 },
                column: "JobName",
                value: "Consultant");

            migrationBuilder.UpdateData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 2, 3 },
                column: "JobName",
                value: "Dev");

            migrationBuilder.UpdateData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 3, 1 },
                column: "JobName",
                value: "Dev");

            migrationBuilder.UpdateData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 3, 2 },
                column: "JobName",
                value: "Dev");

            migrationBuilder.UpdateData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "JobName", "Rate" },
                values: new object[] { "Dev", 500.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobName",
                table: "ConsultantMissions");

            migrationBuilder.UpdateData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 3, 3 },
                column: "Rate",
                value: 400.0);
        }
    }
}
