using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KetchupMayoSite.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ketchups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: false),
                    Spiciness = table.Column<int>(nullable: false),
                    ProductionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ketchups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mayos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: false),
                    Mildness = table.Column<int>(nullable: false),
                    ProductionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mayos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Ketchups",
                columns: new[] { "Id", "Brand", "Name", "ProductionDate", "Spiciness" },
                values: new object[,]
                {
                    { 1, "Pudliszki", "Ketchup Super pikantny", new DateTime(2019, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 2, "Pudliszki", "Ketchup Łagodny", new DateTime(2018, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Mayos",
                columns: new[] { "Id", "Brand", "Mildness", "Name", "ProductionDate" },
                values: new object[,]
                {
                    { 1, "Kielecki", 9, "Majonez zwykły", new DateTime(2019, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Winiary", 10, "Majonez Dekoracyjny", new DateTime(2017, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ketchups");

            migrationBuilder.DropTable(
                name: "Mayos");
        }
    }
}
