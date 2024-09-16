using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityProvider.Database.Migrations
{
    /// <inheritdoc />
    public partial class EnableNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

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
        }
    }
}
