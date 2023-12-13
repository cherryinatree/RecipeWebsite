using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JohnCherry_10_1_TicTacToe.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicTacToe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhosTurn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    square1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    square2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    square3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    square4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    square5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    square6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    square7 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    square8 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    square9 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    whoWon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicTacToe", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TicTacToe",
                columns: new[] { "Id", "WhosTurn", "square1", "square2", "square3", "square4", "square5", "square6", "square7", "square8", "square9", "whoWon" },
                values: new object[] { 1, "X", "", "", "", "", "", "", "", "", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicTacToe");
        }
    }
}
