using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Business_School_VF.Data.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departaments",
                columns: table => new
                {
                    DepartamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartamentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Office_Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departaments", x => x.DepartamentId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ClubId);
                    table.ForeignKey(
                        name: "FK_Clubs_Departaments_DepartamentId",
                        column: x => x.DepartamentId,
                        principalTable: "Departaments",
                        principalColumn: "DepartamentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    InscriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => x.InscriptionId);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departaments",
                columns: new[] { "DepartamentId", "DepartamentName", "Email", "Office_Location", "Phone_Number" },
                values: new object[,]
                {
                    { 1, "Marketing", "marketing@businesschool.com", "Building A - Room 201", "600123456" },
                    { 2, "Finance", "finance@businesschool.com", "Building B - Room 105", "600654321" },
                    { 3, "Management", "management@businesschool.com", "Building C - Room 310", "601111222" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonId", "Birthday", "PersonName", "PersonUser" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos Ruiz", "carlos_ruiz" },
                    { 2, new DateTime(1985, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elena Torres", "elena_torres" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Birthday", "StudentName", "StudentUser" },
                values: new object[,]
                {
                    { 1, new DateTime(2001, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana García", "ana_garcia" },
                    { 2, new DateTime(2000, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis Martínez", "luis_martinez" },
                    { 3, new DateTime(2002, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "María López", "maria_lopez" }
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "ClubId", "ClubName", "DepartamentId" },
                values: new object[,]
                {
                    { 1, "Marketing Student Association", 1 },
                    { 2, "Finance Investment Club", 2 },
                    { 3, "Leadership & Strategy Club", 3 }
                });

            migrationBuilder.InsertData(
                table: "Inscriptions",
                columns: new[] { "InscriptionId", "ClubId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 3, 1 },
                    { 3, 2, 2 },
                    { 4, 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_DepartamentId",
                table: "Clubs",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_ClubId",
                table: "Inscriptions",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_StudentId",
                table: "Inscriptions",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscriptions");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departaments");
        }
    }
}
