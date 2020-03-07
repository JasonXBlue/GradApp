using Microsoft.EntityFrameworkCore.Migrations;

namespace PetAPI.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shelters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    ShelterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Shelters",
                columns: new[] { "Id", "Address", "Name", "Phone" },
                values: new object[] { 1, "3323 SE Loop 289, Lubbock, TX 79404", "Lubbock Animal Shelter & Adoption Center", "(806) 775-2057" });

            migrationBuilder.InsertData(
                table: "Shelters",
                columns: new[] { "Id", "Address", "Name", "Phone" },
                values: new object[] { 2, "4501 Farm to Market Rd 1729, Lubbock, TX 79403", "Haven Animal Care Shelter", "(806) 763-0092" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "Name", "ShelterId", "Type" },
                values: new object[] { 1, 2, "Chewie", 1, "Dog" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "Name", "ShelterId", "Type" },
                values: new object[] { 2, 7, "Han", 2, "Dog" });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ShelterId",
                table: "Animals",
                column: "ShelterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Shelters");
        }
    }
}
