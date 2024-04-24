using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb3Api_V2.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    HobbyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.HobbyId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "WebLinks",
                columns: table => new
                {
                    WebLinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FkHobbyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebLinks", x => x.WebLinkId);
                    table.ForeignKey(
                        name: "FK_WebLinks_Hobbies_FkHobbyId",
                        column: x => x.FkHobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "HobbyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonHobbies",
                columns: table => new
                {
                    PersonHobbyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkPersonId = table.Column<int>(type: "int", nullable: false),
                    FkHobbyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonHobbies", x => x.PersonHobbyId);
                    table.ForeignKey(
                        name: "FK_PersonHobbies_Hobbies_FkHobbyId",
                        column: x => x.FkHobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "HobbyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonHobbies_Persons_FkPersonId",
                        column: x => x.FkPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonHobbies_FkHobbyId",
                table: "PersonHobbies",
                column: "FkHobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonHobbies_FkPersonId",
                table: "PersonHobbies",
                column: "FkPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_WebLinks_FkHobbyId",
                table: "WebLinks",
                column: "FkHobbyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonHobbies");

            migrationBuilder.DropTable(
                name: "WebLinks");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Hobbies");
        }
    }
}
