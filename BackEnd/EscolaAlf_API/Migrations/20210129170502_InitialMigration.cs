using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EscolaAlf_API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionNumber = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentGrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentSituation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Average = table.Column<double>(type: "float", nullable: false),
                    Approval = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSituation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    QuestionNumber = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentReply",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TestQuestionId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentReply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentReply_TestQuestion_TestQuestionId",
                        column: x => x.TestQuestionId,
                        principalTable: "TestQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Template",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestQuestionId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Template_TestQuestion_TestQuestionId",
                        column: x => x.TestQuestionId,
                        principalTable: "TestQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "Description", "OptionNumber", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Pedro Álvares Cabral", 1, 1 },
                    { 19, "Chimarrão", 3, 5 },
                    { 18, "Suco", 2, 5 },
                    { 17, "Leite", 1, 5 },
                    { 16, "Uma empresa de tecnologia", 4, 4 },
                    { 15, "Uma marca de carro", 3, 4 },
                    { 14, "Uma linguagem de programção", 2, 4 },
                    { 13, "Uma ferramenta", 1, 4 },
                    { 12, "H2O", 4, 3 },
                    { 11, "N2", 3, 3 },
                    { 20, "Água", 4, 5 },
                    { 9, "H202", 1, 3 },
                    { 8, "Células de defesa", 4, 2 },
                    { 7, "Células de gordura", 3, 2 },
                    { 6, "Células dos ossos", 2, 2 },
                    { 5, "Células da pele", 1, 2 },
                    { 4, "Michael Jackson", 4, 1 },
                    { 3, "Elizabeth I", 3, 1 },
                    { 2, "Napoleão Bernardes", 2, 1 },
                    { 10, "CH4", 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 4, "O que é 'C#'?" },
                    { 3, "Qual a fórmula da água?" },
                    { 5, "O que a vaca bebe?" },
                    { 1, "Quem descobriu o Brasil?" },
                    { 2, "O que são células adiposas?" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Birthdate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2003, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matheus" },
                    { 2, new DateTime(2003, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristina" },
                    { 3, new DateTime(2004, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diego" },
                    { 4, new DateTime(2003, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ronaldo" },
                    { 5, new DateTime(2002, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emilly" }
                });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "Id", "Date" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TestQuestion",
                columns: new[] { "Id", "QuestionId", "QuestionNumber", "TestId", "Weight" },
                values: new object[,]
                {
                    { 5, 3, 1, 3, 20 },
                    { 1, 1, 1, 1, 5 },
                    { 2, 3, 2, 1, 10 },
                    { 3, 2, 1, 2, 2 },
                    { 4, 4, 2, 2, 3 },
                    { 6, 5, 2, 3, 30 }
                });

            migrationBuilder.InsertData(
                table: "Template",
                columns: new[] { "Id", "OptionId", "TestQuestionId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Template",
                columns: new[] { "Id", "OptionId", "TestQuestionId" },
                values: new object[] { 2, 12, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_StudentReply_TestQuestionId",
                table: "StudentReply",
                column: "TestQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Template_TestQuestionId",
                table: "Template",
                column: "TestQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "StudentGrade");

            migrationBuilder.DropTable(
                name: "StudentReply");

            migrationBuilder.DropTable(
                name: "StudentSituation");

            migrationBuilder.DropTable(
                name: "Template");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "TestQuestion");
        }
    }
}
