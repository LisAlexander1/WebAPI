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
                    { new Guid("23a1a0c6-420f-43f0-b825-291c1f1cc2c4"), "Яблоко", 10.0 },
                    { new Guid("59f4b265-7847-4a0e-a241-a56b2d096507"), "Пистолет", 7214.0 },
                    { new Guid("9a779d9c-2ba1-4c3a-99a2-a07a56bec562"), "Груша", 5040.0 },
                    { new Guid("9f9695ba-3cd9-4c88-9c94-00c8a98693c0"), "Schützenpanzerwagen", 7543.0 },
                    { new Guid("ccb544e5-b96c-45ae-b891-f70e31c978b4"), "Транзистор", 5899.0 },
                    { new Guid("da013aea-0169-4b1c-bf75-7cbfec2953d5"), "Лопасть вертолета Apache", 8431.0 },
                    { new Guid("fdf86d11-4349-4916-ae70-c893da24ec8a"), "Первая ступень ракетоносителя Союз-1Б", 3397.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password" },
                values: new object[] { new Guid("b1489d39-9258-42ad-a772-e04d904ac88c"), "admin@example.com", "$2a$11$0LRl7J.9XF8Ss0Op5j2Ece7dOpNl.QsHw85GnuLuMWCqmjxdhHRIi" });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "ProductId", "SellDateTime", "SellsCount" },
                values: new object[,]
                {
                    { new Guid("569ed383-61e9-416f-a297-1ed7b3e16f91"), new Guid("ccb544e5-b96c-45ae-b891-f70e31c978b4"), new DateTime(2004, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 77 },
                    { new Guid("5dbb2b57-150c-4ddf-b7a7-49b92f84e698"), new Guid("9f9695ba-3cd9-4c88-9c94-00c8a98693c0"), new DateTime(2011, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 22 },
                    { new Guid("6732a0fe-a519-4ba8-a43b-7646169dfd60"), new Guid("59f4b265-7847-4a0e-a241-a56b2d096507"), new DateTime(2018, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 48 },
                    { new Guid("71ac6cd5-4588-4a4a-9da2-e9df71ebad17"), new Guid("59f4b265-7847-4a0e-a241-a56b2d096507"), new DateTime(2018, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 71 },
                    { new Guid("7a7a7c19-6d00-4584-8318-d7916bf65862"), new Guid("ccb544e5-b96c-45ae-b891-f70e31c978b4"), new DateTime(2022, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { new Guid("803a2477-485a-4ad3-99dd-537229bbb578"), new Guid("9f9695ba-3cd9-4c88-9c94-00c8a98693c0"), new DateTime(2007, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { new Guid("863f3873-bafe-453d-a15c-345688b870d0"), new Guid("fdf86d11-4349-4916-ae70-c893da24ec8a"), new DateTime(2021, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 83 },
                    { new Guid("897d38eb-98cf-4a96-9448-bfd0e1793d98"), new Guid("fdf86d11-4349-4916-ae70-c893da24ec8a"), new DateTime(2007, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 25 },
                    { new Guid("8d75d84f-503e-47df-a49e-d16cb86a583e"), new Guid("9f9695ba-3cd9-4c88-9c94-00c8a98693c0"), new DateTime(2002, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 77 },
                    { new Guid("947f8009-4d39-4350-a269-0181887af3d1"), new Guid("23a1a0c6-420f-43f0-b825-291c1f1cc2c4"), new DateTime(2018, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 93 },
                    { new Guid("c00342e2-b14c-431a-b052-eea73dbf56bc"), new Guid("9f9695ba-3cd9-4c88-9c94-00c8a98693c0"), new DateTime(2008, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { new Guid("cf6445c7-1ee5-49ec-8efe-2f5650a29561"), new Guid("23a1a0c6-420f-43f0-b825-291c1f1cc2c4"), new DateTime(2005, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { new Guid("d5894c4d-8599-40d3-bcb1-b9b1dfd52a36"), new Guid("9a779d9c-2ba1-4c3a-99a2-a07a56bec562"), new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 17 },
                    { new Guid("f4a45fd1-752e-489f-b018-eaae3b83e4df"), new Guid("9f9695ba-3cd9-4c88-9c94-00c8a98693c0"), new DateTime(2014, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 97 },
                    { new Guid("f9cabe17-d305-47fa-a1db-09fb56eb4c92"), new Guid("ccb544e5-b96c-45ae-b891-f70e31c978b4"), new DateTime(2014, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 78 }
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
