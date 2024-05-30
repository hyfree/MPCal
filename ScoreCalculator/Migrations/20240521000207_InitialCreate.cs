using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScoreCalculator.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecordEntryEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectId = table.Column<long>(type: "INTEGER", nullable: false),
                    SecurityDimension = table.Column<int>(type: "INTEGER", nullable: false),
                    ZhiBiao = table.Column<string>(type: "TEXT", nullable: false),
                    Index = table.Column<string>(type: "TEXT", nullable: true),
                    TestObjectName = table.Column<string>(type: "TEXT", nullable: true),
                    ZhiBiaoYaoqQiu = table.Column<string>(type: "TEXT", nullable: true),
                    ZhiBiaoQuanZhong = table.Column<double>(type: "REAL", nullable: false),
                    CePingDanYuanDeFen = table.Column<double>(type: "REAL", nullable: true),
                    ZheHeFenShu = table.Column<double>(type: "REAL", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    EnabledAutomatic = table.Column<bool>(type: "INTEGER", nullable: true),
                    TestStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    Exposures = table.Column<int>(type: "INTEGER", nullable: false),
                    D = table.Column<bool>(type: "INTEGER", nullable: false),
                    A = table.Column<bool>(type: "INTEGER", nullable: false),
                    K = table.Column<bool>(type: "INTEGER", nullable: false),
                    NK = table.Column<bool>(type: "INTEGER", nullable: false),
                    RA = table.Column<int>(type: "INTEGER", nullable: false),
                    RK = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordEntryEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemInfoEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<long>(type: "INTEGER", nullable: false),
                    Provinces = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemInfoEntity", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordEntryEntity");

            migrationBuilder.DropTable(
                name: "SystemInfoEntity");
        }
    }
}
