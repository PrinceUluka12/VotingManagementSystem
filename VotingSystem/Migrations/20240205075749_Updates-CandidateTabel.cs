using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatesCandidateTabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Positions_RunningForId",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "RunningForId",
                table: "Candidates",
                newName: "PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Candidates_RunningForId",
                table: "Candidates",
                newName: "IX_Candidates_PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Positions_PositionId",
                table: "Candidates",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Positions_PositionId",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "Candidates",
                newName: "RunningForId");

            migrationBuilder.RenameIndex(
                name: "IX_Candidates_PositionId",
                table: "Candidates",
                newName: "IX_Candidates_RunningForId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Positions_RunningForId",
                table: "Candidates",
                column: "RunningForId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
