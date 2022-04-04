using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Measurement.WebApi.Migrations
{
    public partial class initMssql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measurement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurement", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Measurement",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "111" },
                    { 2, "222" },
                    { 3, "333" },
                    { 4, "444" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurement");
        }
    }
}
