using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityProvider.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddUserLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("0d66cdf2-6bb1-4745-9626-e28383035444"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("40238184-4110-416a-84d6-306b45225ea7"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("535f4609-7c41-4e0a-9433-25e14fe8581d"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("73750a07-1534-4462-803b-08b4eb19cbaa"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("a5441b4d-ac86-470e-8cd4-5f027b9437c0"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("aa20587a-2403-4e40-ba5a-5399aeb2e9d1"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c4544191-baa1-4fe5-894c-19867978b062"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("f568430c-7fd0-4afc-a8ab-21d7468f0f0b"));

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Provider = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ProviderIdentityKey = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
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
                    { new Guid("08435fb2-6a0e-4b7d-88f4-130947397a67"), "671b72d2-8655-4fb0-9ed5-59826842871b", "given_name", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "Dũng" },
                    { new Guid("26be2f78-e1cc-4033-9478-5b277dcbc322"), "d4b8ddb8-22f8-4d87-ba48-714cda184c3a", "role", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "Admin" },
                    { new Guid("2ee539e3-1256-401f-9ba1-0810622fbb6b"), "448f0773-b75c-4491-bbf6-a3863bd83f45", "country", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "vn" },
                    { new Guid("5bf608d3-4e77-447d-a185-0dfa11d3c196"), "231f4c32-1e80-42a3-924c-d602a13119ab", "role", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "Customer" },
                    { new Guid("6f5b1f0b-b402-40a2-89c7-cd327d0a2d9f"), "a2c63b26-e66d-4a0a-b4cf-2a79ae041d73", "family_name", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "Tấn" },
                    { new Guid("8d4e2b9c-aab0-4ecb-acb5-f457212cb95a"), "18ce75d3-57a2-4132-8191-b29e64e1095f", "country", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "cn" },
                    { new Guid("adeda7a6-8336-4f6e-b9c9-4401e6144567"), "4075953c-f325-46aa-b6aa-12b09904a8fe", "given_name", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "Cường" },
                    { new Guid("c121fd73-ec4c-4182-b5a0-de483b1c017b"), "da12ad88-48ba-49b3-b316-da833d777e52", "family_name", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "Nguyễn" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"),
                columns: new[] { "ConcurrencyStamp", "Password", "Subject" },
                values: new object[] { "78f13507-9602-452c-a69f-2122ed938b29", "AQAAAAIAAYagAAAAEB5Hd+NJ2VoB35V3X0vXYHi9Lfo0oaSMWHcOVFyUwtVGiafNpkFhCWnErV9p3V5+ig==", "b9ebf3fd-e42c-4514-bfb4-6266bb5a55e7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"),
                columns: new[] { "ConcurrencyStamp", "Password", "Subject" },
                values: new object[] { "f988317b-68fd-4642-bc9d-c929e957b8fd", "AQAAAAIAAYagAAAAEIIxIqb+BIr8sVrz4ajEq6UmpP4grpHsH6rvpAi1jr0TebKi0BXhosbHY6GHlEckMA==", "7bae0f06-1569-48b9-835e-a7b4f1f537c1" });

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("08435fb2-6a0e-4b7d-88f4-130947397a67"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("26be2f78-e1cc-4033-9478-5b277dcbc322"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("2ee539e3-1256-401f-9ba1-0810622fbb6b"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("5bf608d3-4e77-447d-a185-0dfa11d3c196"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("6f5b1f0b-b402-40a2-89c7-cd327d0a2d9f"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("8d4e2b9c-aab0-4ecb-acb5-f457212cb95a"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("adeda7a6-8336-4f6e-b9c9-4401e6144567"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c121fd73-ec4c-4182-b5a0-de483b1c017b"));

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("0d66cdf2-6bb1-4745-9626-e28383035444"), "1ee6f2c5-2b20-413e-83f0-5114d52ba6df", "family_name", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "Nguyễn" },
                    { new Guid("40238184-4110-416a-84d6-306b45225ea7"), "60948b31-fa41-4be6-ad47-dad6cedf40dd", "given_name", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "Dũng" },
                    { new Guid("535f4609-7c41-4e0a-9433-25e14fe8581d"), "80907a9a-f462-44c8-96dd-f7c29d7727fc", "role", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "Customer" },
                    { new Guid("73750a07-1534-4462-803b-08b4eb19cbaa"), "33be7372-fb81-40d0-800f-49278cbbe9d6", "country", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "vn" },
                    { new Guid("a5441b4d-ac86-470e-8cd4-5f027b9437c0"), "bdb2817d-6b84-443a-bac6-b4963ab091db", "country", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "cn" },
                    { new Guid("aa20587a-2403-4e40-ba5a-5399aeb2e9d1"), "ebcba1a5-5820-4057-aa9b-33782419089f", "family_name", new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"), "Tấn" },
                    { new Guid("c4544191-baa1-4fe5-894c-19867978b062"), "7e54f7f1-b5d2-474c-a28f-039b06a3ab69", "given_name", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "Cường" },
                    { new Guid("f568430c-7fd0-4afc-a8ab-21d7468f0f0b"), "8d731785-41ef-45c8-bc7a-bfa6dbb8053a", "role", new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"), "Admin" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"),
                columns: new[] { "ConcurrencyStamp", "Password", "Subject" },
                values: new object[] { "52e2fbbc-4aa9-4421-9851-8aaf8622053f", "AQAAAAIAAYagAAAAENGIcCUHaEfvEekxwNSYEk+srUBQjJAKVJT3zrcrSB5PUa4T/7NxpcHW00uAWBsQPA==", "387926a3-9aeb-4037-84fb-924f4e9c7097" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"),
                columns: new[] { "ConcurrencyStamp", "Password", "Subject" },
                values: new object[] { "81506e71-db50-48f6-9d5d-6b124f6e6383", "AQAAAAIAAYagAAAAEColUQRA2h+zCDiWeVmmpm4UcUN4NodKVqwfcRS0jkMMF/nAdvmDRVUPKO9iQzhIpA==", "de1f108f-b527-43bc-b51b-6421ee24bab3" });
        }
    }
}
