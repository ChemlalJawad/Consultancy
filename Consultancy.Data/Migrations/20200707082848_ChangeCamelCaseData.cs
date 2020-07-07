using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultancy.Data.Migrations
{
    public partial class ChangeCamelCaseData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "ConsultantMissions",
                newName: "IsActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ConsultantMissions",
                newName: "isActive");
        }
    }
}
