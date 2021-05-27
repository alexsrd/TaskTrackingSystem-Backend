using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTrackingSystem.DAL.Migrations
{
    public partial class DatabaseSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3005b7c4-328d-4626-9f8f-cfe8b9b12c9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0fe4cd9-7871-40a5-945c-41195b4f1a92");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "298f35ac-8118-4d67-a3d5-e0e31f91af37", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "298f35ac-8118-4d67-a3d5-e0e31f91af37");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e45d9a3a-f9de-4635-97ea-e36a0e172125", "54c5f63f-9ca4-43d7-ab6f-670f740c2a94", "User", null },
                    { "c1775921-e0c7-41db-903b-cb6888bf2083", "7b257412-44ee-42b5-b524-e80c9f387869", "Manager", null },
                    { "cb4749cd-a055-4ea5-bfa0-38b1e6310c14", "c2b2d2aa-68db-4634-a62a-d7a5e5aa00df", "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6558c9e9-21f4-4b7a-a6ea-1117662520e1", 0, "0a59870b-eef2-4c2e-96ce-3bcc3775e382", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEKMe+wQWvyETtV0Xngott8hFFTSZcFF626ABUSO1sMHgGZi/p70Hq05GvXqumn2n/g==", null, false, "9b4668f9-7d6f-4ac3-a3bd-ca904e768a8d", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cb4749cd-a055-4ea5-bfa0-38b1e6310c14", "6558c9e9-21f4-4b7a-a6ea-1117662520e1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1775921-e0c7-41db-903b-cb6888bf2083");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e45d9a3a-f9de-4635-97ea-e36a0e172125");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cb4749cd-a055-4ea5-bfa0-38b1e6310c14", "6558c9e9-21f4-4b7a-a6ea-1117662520e1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb4749cd-a055-4ea5-bfa0-38b1e6310c14");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6558c9e9-21f4-4b7a-a6ea-1117662520e1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3005b7c4-328d-4626-9f8f-cfe8b9b12c9a", "7aeb0132-c6b4-46a3-a13e-1439e146c6c4", "User", null },
                    { "e0fe4cd9-7871-40a5-945c-41195b4f1a92", "fe636226-2f1c-4b07-b4c5-7bcc2541c552", "Manager", null },
                    { "298f35ac-8118-4d67-a3d5-e0e31f91af37", "94caf0e2-a60d-4164-a25b-ce92aa07c988", "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "005a16d2-9ef5-4af1-88c5-675ce1217993", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEF1fN/4SHjMDKVQMaQmApfsPsN7hg+QziT+1isRzQhtBOTJi5ebdWJkjv6jchiWk1A==", null, false, "ded7411a-6438-4ee5-8e95-217a120a8c31", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "298f35ac-8118-4d67-a3d5-e0e31f91af37", "1" });
        }
    }
}
