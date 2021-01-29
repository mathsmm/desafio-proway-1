using Microsoft.EntityFrameworkCore.Migrations;

namespace EscolaAlf_API.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StudentReply",
                columns: new[] { "Id", "OptionId", "StudentId", "TestQuestionId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "StudentReply",
                columns: new[] { "Id", "OptionId", "StudentId", "TestQuestionId" },
                values: new object[] { 2, 11, 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentReply",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentReply",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
