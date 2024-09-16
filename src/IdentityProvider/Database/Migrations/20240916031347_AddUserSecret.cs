using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityProvider.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSecret : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("34ec654d-779a-46ba-bd02-b454932e358b"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("72b3a615-b441-4844-8fd9-ec555bb4071c"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("78b03b17-60c2-4973-80e6-1e0960dd427d"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("8766fb34-cd09-43a0-b2f6-472910eb16f4"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("9cf2296b-687a-481a-98a5-37847b9a176f"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("b9a7a656-322b-4940-8a77-374cbc18e147"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c197df6e-0f69-4658-a71d-677841c74fa8"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("d3f75946-a119-4eb1-8a7b-25bc538e07f3"));

            migrationBuilder.CreateTable(
                name: "UserSecrets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Secret = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSecrets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("129e2349-4c76-4527-88bc-f0a53c25329e"), "d6c383e2-79cf-4cec-964c-6bbaf571bed2", "given_name", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "Dũng" },
                    { new Guid("1af44c41-ec2c-4b54-a472-b4f04939254e"), "570c6656-8520-4a43-9c41-a22476dc2a06", "role", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "Customer" },
                    { new Guid("260e277c-a44c-4762-a0da-660e5138ea70"), "91fc7bb8-07eb-4fa9-9f0a-96758540cd39", "country", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "cn" },
                    { new Guid("3fb7cb2d-0e29-4077-a8e5-050e29138dcf"), "44e548e4-afcc-4e82-9267-c2a876ad4926", "country", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "vn" },
                    { new Guid("6c7ce8fa-7502-4a94-aae6-600b32e22e1f"), "3aae3036-57d9-4fcc-b7c4-9ce213460308", "family_name", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "Tấn" },
                    { new Guid("d55f7869-b8fc-4580-8973-15baa2902e11"), "c01e2f4b-6567-40cd-804a-5c0540eb1582", "family_name", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "Nguyễn" },
                    { new Guid("e81a90f1-6a9a-472b-b5fa-a7bc8207b745"), "70361225-de43-4672-b591-c4fd28f3a403", "given_name", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "Cường" },
                    { new Guid("e8334b5f-684d-474e-aaa2-55586cfa6d99"), "3fb8bd29-9877-44af-9374-fd3713541e23", "role", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "Admin" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"),
                columns: new[] { "ConcurrencyStamp", "Password", "Subject" },
                values: new object[] { "7980d396-2c5a-482a-9e73-03e752ffab1d", "AQAAAAIAAYagAAAAEPnu03M2TC6log3ArM6kDMS/8mRn2U0wLlz7kuctiweQ5hA4alBNV5VfkXhjyjY0YA==", "ebaa3858-a1f1-4a25-bfd6-4b68c1fc3532" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"),
                columns: new[] { "ConcurrencyStamp", "Password", "Subject" },
                values: new object[] { "9da467cc-22d6-45bd-854c-8dfe3d4741cc", "AQAAAAIAAYagAAAAEBR4zbtM8+ufigRscKBIm0Sybqj/+VxPmeAyBVhdHjsS3pHs+rPrx/8REBSh15DaBQ==", "823e4276-e05a-4540-b61d-f69c927c6aae" });

            migrationBuilder.CreateIndex(
                name: "IX_UserSecrets_UserId",
                table: "UserSecrets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSecrets");

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("129e2349-4c76-4527-88bc-f0a53c25329e"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("1af44c41-ec2c-4b54-a472-b4f04939254e"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("260e277c-a44c-4762-a0da-660e5138ea70"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("3fb7cb2d-0e29-4077-a8e5-050e29138dcf"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("6c7ce8fa-7502-4a94-aae6-600b32e22e1f"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("d55f7869-b8fc-4580-8973-15baa2902e11"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e81a90f1-6a9a-472b-b5fa-a7bc8207b745"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e8334b5f-684d-474e-aaa2-55586cfa6d99"));

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("34ec654d-779a-46ba-bd02-b454932e358b"), "8b8355b6-97c5-40f7-989b-17c84141dad2", "role", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "Customer" },
                    { new Guid("72b3a615-b441-4844-8fd9-ec555bb4071c"), "00536d5b-1ea6-435a-a96d-906a367c5bee", "family_name", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "Nguyễn" },
                    { new Guid("78b03b17-60c2-4973-80e6-1e0960dd427d"), "482eb0e8-a011-4910-9c21-9b8933f4b6bf", "family_name", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "Tấn" },
                    { new Guid("8766fb34-cd09-43a0-b2f6-472910eb16f4"), "dda963e9-6108-4c27-b1c7-0a76683d762d", "country", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "cn" },
                    { new Guid("9cf2296b-687a-481a-98a5-37847b9a176f"), "2bdae41d-0e04-4408-bd91-aaa9039cbb3d", "role", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "Admin" },
                    { new Guid("b9a7a656-322b-4940-8a77-374cbc18e147"), "f121db14-8247-49aa-a100-918fa321b8aa", "given_name", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "Dũng" },
                    { new Guid("c197df6e-0f69-4658-a71d-677841c74fa8"), "fbfdfc40-e25c-40aa-b92c-4a7c56e71e0d", "given_name", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "Cường" },
                    { new Guid("d3f75946-a119-4eb1-8a7b-25bc538e07f3"), "db25a234-7495-4755-aa1a-3dfe9e39efee", "country", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "vn" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"),
                columns: new[] { "ConcurrencyStamp", "Password", "Subject" },
                values: new object[] { "e932c391-7c9b-411b-8c90-bcb128ed2839", "AQAAAAIAAYagAAAAECOtO9SY5lL3SgD5smsFNrebBiLh3PVm7EHwJFIZekfOlVsS0M0afRUAdrY9HfLT5Q==", "a2ba2c81-486f-46e0-aa42-3d3ee8665f53" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"),
                columns: new[] { "ConcurrencyStamp", "Password", "Subject" },
                values: new object[] { "71ca5ba2-1d2f-489f-abce-9c580dbc96c0", "AQAAAAIAAYagAAAAEE0MNwa4ESudTiuuwT6MaA7tooDw2yOBw8X4TYv5D6N3/4R4LL6fTJXTVtL/m1IRhQ==", "e6246359-1371-48af-800f-45982491163a" });
        }
    }
}
