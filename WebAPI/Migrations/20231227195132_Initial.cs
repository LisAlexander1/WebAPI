using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("02f35729-4fe4-4a15-a40c-294be3c7462c"), "Schützenpanzerwagen", 7543.0 },
                    { new Guid("310ac857-1365-4657-8b5e-cb2c620589dd"), "Первая ступень ракетоносителя Союз-1Б", 3397.0 },
                    { new Guid("31f8b402-4f29-4234-a5d3-2e843e1adeed"), "Пистолет", 7214.0 },
                    { new Guid("43cab4a1-2023-462b-bbb6-1548723f4a9b"), "Яблоко", 10.0 },
                    { new Guid("6cccc01a-eb96-4465-a476-30f7276d6f7f"), "Лопасть вертолета Apache", 8431.0 },
                    { new Guid("83051721-c684-4d33-b27b-be88891d0305"), "Груша", 5040.0 },
                    { new Guid("e2a5a28e-1bce-4d56-990e-136163dcb6df"), "Транзистор", 5899.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password" },
                values: new object[] { new Guid("7b1b1769-984a-4836-9ba7-668def165b97"), "admin@example.com", "$2a$11$PbcI7pY0C9ukDXcTIgyDJupQ.xKI3Kt0/NpbWrK.vYyRiSrXjexb6" });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "ProductId", "SellDateTime", "SellsCount" },
                values: new object[,]
                {
                    { new Guid("035ac37e-861d-426f-9beb-931687c8363b"), new Guid("e2a5a28e-1bce-4d56-990e-136163dcb6df"), new DateTime(2008, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 27 },
                    { new Guid("05fa68e7-903f-456f-9d81-43964828fe5b"), new Guid("310ac857-1365-4657-8b5e-cb2c620589dd"), new DateTime(2011, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 88 },
                    { new Guid("309eb85e-dc03-4de7-ac03-2c4962299230"), new Guid("6cccc01a-eb96-4465-a476-30f7276d6f7f"), new DateTime(2012, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 39 },
                    { new Guid("3c120025-62c5-492f-a2a9-8a24e3e96683"), new Guid("310ac857-1365-4657-8b5e-cb2c620589dd"), new DateTime(2016, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 63 },
                    { new Guid("53aa784e-2854-4dee-917d-8ca6692f100b"), new Guid("02f35729-4fe4-4a15-a40c-294be3c7462c"), new DateTime(2009, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 35 },
                    { new Guid("63255f21-b178-4ae4-bde7-33bca5bdd0e2"), new Guid("310ac857-1365-4657-8b5e-cb2c620589dd"), new DateTime(2013, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 61 },
                    { new Guid("6a037672-80f0-4869-b570-1895efafe628"), new Guid("6cccc01a-eb96-4465-a476-30f7276d6f7f"), new DateTime(2004, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 31 },
                    { new Guid("71396019-4900-444c-a3d4-dfdbf8a0cc73"), new Guid("6cccc01a-eb96-4465-a476-30f7276d6f7f"), new DateTime(2020, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 70 },
                    { new Guid("9e5c7f48-c2c9-4164-9662-1438ddb8da08"), new Guid("83051721-c684-4d33-b27b-be88891d0305"), new DateTime(2007, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 81 },
                    { new Guid("cf0b63da-6a34-4dff-9313-a841a9a659b4"), new Guid("02f35729-4fe4-4a15-a40c-294be3c7462c"), new DateTime(2014, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { new Guid("d23fe653-0d99-4e8c-86ed-6ad346e84be5"), new Guid("83051721-c684-4d33-b27b-be88891d0305"), new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 99 },
                    { new Guid("d287899c-7fe0-425b-855c-a57a858404e3"), new Guid("83051721-c684-4d33-b27b-be88891d0305"), new DateTime(2003, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 83 },
                    { new Guid("dacfaf55-3c16-43e9-b35f-1640c75b1a4c"), new Guid("83051721-c684-4d33-b27b-be88891d0305"), new DateTime(2016, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("e1ab754b-6cf3-47b4-9d01-8e2db3007dbd"), new Guid("02f35729-4fe4-4a15-a40c-294be3c7462c"), new DateTime(2004, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 52 },
                    { new Guid("fb3ada67-8914-4383-8013-88942a4c4da9"), new Guid("6cccc01a-eb96-4465-a476-30f7276d6f7f"), new DateTime(2009, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 98 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
