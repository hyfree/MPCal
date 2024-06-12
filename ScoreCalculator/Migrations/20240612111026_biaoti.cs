using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScoreCalculator.Migrations
{
    /// <inheritdoc />
    public partial class biaoti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "KnowledgeEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "KnowledgeEntity");
        }
    }
}
