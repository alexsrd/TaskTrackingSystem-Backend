using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTrackingSystem.DAL.Migrations
{
    public partial class FixForeignUserKeyInTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62bb8b54-5d00-4e87-82bc-8682fa278b99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71c36e6e-4c3e-4069-8526-e0bd48b98f15");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "16163dd5-8b29-4c28-a5bd-d8b1462cedbb", "7b87b2bf-1550-4b28-8b5b-2b9eb2e20c30" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16163dd5-8b29-4c28-a5bd-d8b1462cedbb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b87b2bf-1550-4b28-8b5b-2b9eb2e20c30");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f7b6be4-4783-47c2-a349-2c24b873f92a", "7588a27f-c052-4929-b085-360c06c86dce", "User", "USER" },
                    { "8b8126a9-a3ff-4ffb-b94e-fb19d167640f", "af10d275-a3d5-47b6-aab5-83f180f6a81d", "Manager", "MANAGER" },
                    { "bc9582a3-58fb-4661-adeb-64961887ceed", "bbf27499-6e9e-43cf-9891-f49187b631cc", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fc25f3c5-5752-46fc-95e5-6348a6d97171", 0, "c6cb8f58-cb93-4093-a18d-bd7ba6613a2b", "admin@gmail.com", false, null, false, null, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAELLfXMRtkfzKgyVvCfvwYf/+jDJUs5jGS9X9o0sj2OEaOFU2dDOzrM0NkW3Ms9DxJw==", null, false, "Admin", "703d8398-5353-461d-b942-81aedf2d1a84", null, false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bc9582a3-58fb-4661-adeb-64961887ceed", "fc25f3c5-5752-46fc-95e5-6348a6d97171" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f7b6be4-4783-47c2-a349-2c24b873f92a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b8126a9-a3ff-4ffb-b94e-fb19d167640f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bc9582a3-58fb-4661-adeb-64961887ceed", "fc25f3c5-5752-46fc-95e5-6348a6d97171" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc9582a3-58fb-4661-adeb-64961887ceed");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc25f3c5-5752-46fc-95e5-6348a6d97171");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "71c36e6e-4c3e-4069-8526-e0bd48b98f15", "d38622f4-5769-4c8a-b410-425faa3141a2", "User", "USER" },
                    { "62bb8b54-5d00-4e87-82bc-8682fa278b99", "2d8e1a0a-9dbe-4634-bb3c-1ba06c77e70d", "Manager", "MANAGER" },
                    { "16163dd5-8b29-4c28-a5bd-d8b1462cedbb", "db678d99-2fef-487f-9172-526791a19b93", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7b87b2bf-1550-4b28-8b5b-2b9eb2e20c30", 0, "a32f55aa-b7e0-4c88-a965-2240359ada2f", "admin@gmail.com", false, null, false, null, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEHyEfDxyy+FjeTmldZaG0KtZvXZcchUbtjh4coeAUzCzZ+Ruwdcu9Y1injsWRQDFHw==", null, false, null, "752d3e05-e0ee-41f2-81f9-e090ae792602", null, false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "16163dd5-8b29-4c28-a5bd-d8b1462cedbb", "7b87b2bf-1550-4b28-8b5b-2b9eb2e20c30" });
        }
    }
}
