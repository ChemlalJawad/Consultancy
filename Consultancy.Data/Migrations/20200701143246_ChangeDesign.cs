using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultancy.Data.Migrations
{
    public partial class ChangeDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MaximumRate",
                table: "Missions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "ConsultantMissions",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 1, 3 },
                column: "Rate",
                value: 400.0);

            migrationBuilder.UpdateData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 2, 1 },
                column: "Rate",
                value: 400.0);

            migrationBuilder.UpdateData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 2, 3 },
                column: "Rate",
                value: 400.0);

            migrationBuilder.UpdateData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 3, 1 },
                column: "Rate",
                value: 400.0);

            migrationBuilder.UpdateData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 3, 2 },
                column: "Rate",
                value: 400.0);

            migrationBuilder.UpdateData(
                table: "ConsultantMissions",
                keyColumns: new[] { "ConsultantId", "MissionId" },
                keyValues: new object[] { 3, 3 },
                column: "Rate",
                value: 400.0);

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaximumRate",
                value: 500.0);

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaximumRate",
                value: 700.0);

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 3,
                column: "MaximumRate",
                value: 400.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "ConsultantMissions");

            migrationBuilder.AlterColumn<int>(
                name: "MaximumRate",
                table: "Missions",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaximumRate",
                value: 500);

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaximumRate",
                value: 700);

            migrationBuilder.UpdateData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 3,
                column: "MaximumRate",
                value: 400);
        }
    }
}
