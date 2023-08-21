using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BornToMove.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RatingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sweatRate",
                table: "Move");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Move",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Move",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Move",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "MoveRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    moveId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Vote = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoveRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoveRating_Move_moveId",
                        column: x => x.moveId,
                        principalTable: "Move",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoveRating_moveId",
                table: "MoveRating",
                column: "moveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoveRating");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Move",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Move",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Move",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "sweatRate",
                table: "Move",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
