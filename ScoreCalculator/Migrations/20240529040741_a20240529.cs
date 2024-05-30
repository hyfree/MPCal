using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScoreCalculator.Migrations
{
    /// <inheritdoc />
    public partial class a20240529 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "RecordEntryEntity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suggest",
                table: "RecordEntryEntity",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question",
                table: "RecordEntryEntity");

            migrationBuilder.DropColumn(
                name: "Suggest",
                table: "RecordEntryEntity");
        }
    }
}
