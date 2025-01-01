using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeriodicTable.API.Migrations
{
    /// <inheritdoc />
    public partial class addAppearenceAndPhaseToElement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Appearance",
                table: "Elements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phase",
                table: "Elements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Appearance",
                table: "Elements");

            migrationBuilder.DropColumn(
                name: "Phase",
                table: "Elements");
        }
    }
}
