using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeriodicTable.API.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToElement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Gnumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Gnumber);
                });

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Enumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ESymbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtomicMass = table.Column<double>(type: "float", nullable: false),
                    MeltingPoint = table.Column<double>(type: "float", nullable: false),
                    BoilingPoint = table.Column<double>(type: "float", nullable: false),
                    Gnumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Enumber);
                    table.ForeignKey(
                        name: "FK_Elements_Groups_Gnumber",
                        column: x => x.Gnumber,
                        principalTable: "Groups",
                        principalColumn: "Gnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elements_Gnumber",
                table: "Elements",
                column: "Gnumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
