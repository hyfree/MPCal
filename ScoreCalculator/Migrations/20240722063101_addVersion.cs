using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScoreCalculator.Migrations
{
    /// <inheritdoc />
    public partial class addVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "RecordEntryEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "RecordEntryEntity");
        }
    }
}
