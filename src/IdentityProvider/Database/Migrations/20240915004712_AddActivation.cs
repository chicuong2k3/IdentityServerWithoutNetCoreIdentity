using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityProvider.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddActivation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("06b6e3b3-6616-4818-94c3-e0255b155040"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("4dce1fbd-3ab7-4a56-a4f0-2d837c03264e"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("6225451f-4b8a-4772-b3d8-993da8858ad6"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("767fd588-a023-4eb0-8d01-1053d96de823"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("9694f12a-26d7-438f-9f7d-66420196992c"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c75e32ea-b9cc-4452-bb99-03fd587e8ee6"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("f92cf0d8-25bd-411f-bd4d-74f99f2000a4"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("fdfeda19-a1c6-47e6-8144-4e350af4ca71"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecurityCode",
                table: "Users",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SecurityCodeExpirationDate",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                columns: new[] { "ConcurrencyStamp", "Email", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject" },
                values: new object[] { "52e2fbbc-4aa9-4421-9851-8aaf8622053f", "tandung@gmail.com", "AQAAAAIAAYagAAAAENGIcCUHaEfvEekxwNSYEk+srUBQjJAKVJT3zrcrSB5PUa4T/7NxpcHW00uAWBsQPA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "387926a3-9aeb-4037-84fb-924f4e9c7097" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"),
                columns: new[] { "ConcurrencyStamp", "Email", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject" },
                values: new object[] { "81506e71-db50-48f6-9d5d-6b124f6e6383", "chicuong123@gmail.com", "AQAAAAIAAYagAAAAEColUQRA2h+zCDiWeVmmpm4UcUN4NodKVqwfcRS0jkMMF/nAdvmDRVUPKO9iQzhIpA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "de1f108f-b527-43bc-b51b-6421ee24bab3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCodeExpirationDate",
                table: "Users");

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"),
                columns: new[] { "ConcurrencyStamp", "Password", "Subject" },
                values: new object[] { "7c9483fa-0125-4fa0-a920-d3d584685f98", "dung", "f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e1b4a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"),
                columns: new[] { "ConcurrencyStamp", "Password", "Subject" },
                values: new object[] { "54285629-8276-490d-998a-ddd76c848e46", "cuong", "f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e9a7b" });
        }
    }
}
