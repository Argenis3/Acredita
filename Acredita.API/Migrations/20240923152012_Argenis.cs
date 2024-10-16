using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acredita.API.Migrations
{
    /// <inheritdoc />
    public partial class Argenis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_universities",
                table: "universities");

            migrationBuilder.RenameTable(
                name: "universities",
                newName: "Universities");

            migrationBuilder.RenameIndex(
                name: "IX_universities_Name",
                table: "Universities",
                newName: "IX_Universities_Name");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Universities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Universities",
                table: "Universities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    duration = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Length = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Majors_Name",
                table: "Majors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Name",
                table: "Projects",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Majors");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Universities",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Universities");

            migrationBuilder.RenameTable(
                name: "Universities",
                newName: "universities");

            migrationBuilder.RenameIndex(
                name: "IX_Universities_Name",
                table: "universities",
                newName: "IX_universities_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_universities",
                table: "universities",
                column: "Id");
        }
    }
}
