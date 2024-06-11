using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScoreCalculator.Migrations
{
    /// <inheritdoc />
    public partial class zhishiku : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Feature",
                table: "RecordEntryEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "RecordEntryEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "KnowledgeEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SecurityDimensionEnum = table.Column<int>(type: "INTEGER", nullable: false),
                    Feature = table.Column<string>(type: "TEXT", nullable: false),
                    ZhiBiao = table.Column<string>(type: "TEXT", nullable: false),
                    Tag = table.Column<string>(type: "TEXT", nullable: false),
                    TestStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeEntity", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KnowledgeEntity");

            migrationBuilder.DropColumn(
                name: "Feature",
                table: "RecordEntryEntity");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "RecordEntryEntity");
        }
    }
}
