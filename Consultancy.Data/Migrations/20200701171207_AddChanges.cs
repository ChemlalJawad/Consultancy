using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultancy.Data.Migrations
{
    public partial class AddChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 3, 2 },
                column: "isActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 3, 3 },
                column: "isActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 3, 2 },
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 3, 3 },
                column: "isActive",
                value: false);
        }
    }
}
