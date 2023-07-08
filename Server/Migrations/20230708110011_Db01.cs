using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeacherTest.Server.Migrations
{
    public partial class Db01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "ClassTeachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discripation",
                table: "ClassTeachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ClassTeachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "ClassTeachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "ClassTeachers");

            migrationBuilder.DropColumn(
                name: "Discripation",
                table: "ClassTeachers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ClassTeachers");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "ClassTeachers");
        }
    }
}
