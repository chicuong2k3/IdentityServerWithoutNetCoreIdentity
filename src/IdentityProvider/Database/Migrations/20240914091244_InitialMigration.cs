using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityProvider.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Password", "Subject", "UserName" },
                values: new object[,]
                {
                    { new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), true, "7c9483fa-0125-4fa0-a920-d3d584685f98", "dung", "f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e1b4a", "dung" },
                    { new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), true, "54285629-8276-490d-998a-ddd76c848e46", "cuong", "f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e9a7b", "cuong" }
                });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("06b6e3b3-6616-4818-94c3-e0255b155040"), "43be7aa1-9de6-4f42-a690-2318b1a67f71", "country", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "cn" },
                    { new Guid("4dce1fbd-3ab7-4a56-a4f0-2d837c03264e"), "a501229f-73ce-4a17-90c3-f92b490c22f0", "role", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "Customer" },
                    { new Guid("6225451f-4b8a-4772-b3d8-993da8858ad6"), "525b874b-2fef-46e9-8953-58bccf81d086", "role", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "Admin" },
                    { new Guid("767fd588-a023-4eb0-8d01-1053d96de823"), "541e5a25-fa65-422a-b6bc-dc1256d018e3", "family_name", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "Tấn" },
                    { new Guid("9694f12a-26d7-438f-9f7d-66420196992c"), "0dee4f55-5ab3-4147-9924-2d4ddaddc3c7", "country", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "vn" },
                    { new Guid("c75e32ea-b9cc-4452-bb99-03fd587e8ee6"), "e99a1ffa-addd-4329-b475-98ca6953b783", "given_name", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "Cường" },
                    { new Guid("f92cf0d8-25bd-411f-bd4d-74f99f2000a4"), "6263e021-97e3-4bb2-814c-a62756f7d905", "given_name", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "Dũng" },
                    { new Guid("fdfeda19-a1c6-47e6-8144-4e350af4ca71"), "719cd48d-78af-44c9-b1fe-1e81a7608872", "family_name", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "Nguyễn" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Subject",
                table: "Users",
                column: "Subject",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
