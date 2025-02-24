using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedItemsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    IsDone = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Content", "CreatedAt", "IsDone" },
                values: new object[,]
                {
                    { 1, "Learn C#", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 2, "Learn EF Core", new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 3, "Learn ASP.NET Core", new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 4, "Learn hosting models", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
