using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlassLewis.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exchange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ticker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Exchange", "ISIN", "Name", "Ticker", "Website" },
                values: new object[,]
                {
                    { 1, "NASDAQ", "US0378331005", "Apple Inc.", "AAPL", "http://www.apple.com" },
                    { 2, "Pink Sheets", "US1104193065", "British Airways Plc.", "BAIRY", "" },
                    { 3, "Euronext Amsterdam", "NL0000009165", "Heineken NV", "HEIA", "" },
                    { 4, "Tokyo Stock Exchange", "JP3866800000", "Panasonic Corp", "6752", "http://www.panasonic.co.jp" },
                    { 5, "Deutsche Börse", "DE000PAH0038", "Porsche Automobil", "PAH3", "https://www.porsche.com/" }
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "UserId", "Email", "Password" },
                values: new object[,]
                {
                    { 1, "User1@abc.com", "123456" },
                    { 2, "User2@abc.com", "123456" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
