using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeriodicTable.API.Migrations
{
    /// <inheritdoc />
    public partial class addDiscoverer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discoverers",
                columns: table => new
                {
                    Did = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoB = table.Column<int>(type: "int", nullable: false),
                    Enumber = table.Column<int>(name: "+Enumber", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discoverers", x => x.Did);
                    table.ForeignKey(
                        name: "FK_Discoverers_Groups_+Enumber",
                        column: x => x.Enumber,
                        principalTable: "Groups",
                        principalColumn: "Gnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discoverers_+Enumber",
                table: "Discoverers",
                column: "+Enumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discoverers");
        }
    }
}
