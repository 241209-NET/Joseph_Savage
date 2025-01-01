using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeriodicTable.API.Migrations
{
    /// <inheritdoc />
    public partial class fixedDiscoverer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discoverers_Groups_+Enumber",
                table: "Discoverers");

            migrationBuilder.RenameColumn(
                name: "+Enumber",
                table: "Discoverers",
                newName: "Enumber");

            migrationBuilder.RenameIndex(
                name: "IX_Discoverers_+Enumber",
                table: "Discoverers",
                newName: "IX_Discoverers_Enumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Discoverers_Groups_Enumber",
                table: "Discoverers",
                column: "Enumber",
                principalTable: "Groups",
                principalColumn: "Gnumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discoverers_Groups_Enumber",
                table: "Discoverers");

            migrationBuilder.RenameColumn(
                name: "Enumber",
                table: "Discoverers",
                newName: "+Enumber");

            migrationBuilder.RenameIndex(
                name: "IX_Discoverers_Enumber",
                table: "Discoverers",
                newName: "IX_Discoverers_+Enumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Discoverers_Groups_+Enumber",
                table: "Discoverers",
                column: "+Enumber",
                principalTable: "Groups",
                principalColumn: "Gnumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
