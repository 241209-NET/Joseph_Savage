using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeriodicTable.API.Migrations
{
    /// <inheritdoc />
    public partial class disableAutoIncrementForElements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DropForeignKey(
                name: "FK_Discoverers_Groups_Enumber",
                table: "Discoverers");

            migrationBuilder.AddForeignKey(
                name: "FK_Discoverers_Elements_Enumber",
                table: "Discoverers",
                column: "Enumber",
                principalTable: "Elements",
                principalColumn: "Enumber",
                onDelete: ReferentialAction.Cascade);
                */
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DropForeignKey(
                name: "FK_Discoverers_Elements_Enumber",
                table: "Discoverers");

            migrationBuilder.AddForeignKey(
                name: "FK_Discoverers_Groups_Enumber",
                table: "Discoverers",
                column: "Enumber",
                principalTable: "Groups",
                principalColumn: "Gnumber",
                onDelete: ReferentialAction.Cascade);
                */
        }
    }
}
