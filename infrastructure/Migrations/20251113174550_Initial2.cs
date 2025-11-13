using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CounterId",
                table: "reason",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reason_CounterId",
                table: "reason",
                column: "CounterId");

            migrationBuilder.AddForeignKey(
                name: "FK_reason_counter_CounterId",
                table: "reason",
                column: "CounterId",
                principalTable: "counter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reason_counter_CounterId",
                table: "reason");

            migrationBuilder.DropIndex(
                name: "IX_reason_CounterId",
                table: "reason");

            migrationBuilder.DropColumn(
                name: "CounterId",
                table: "reason");
        }
    }
}
