using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTrackingSystem.DAL.Migrations
{
    public partial class AddFullNameForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62d99878-b51d-408e-8e76-2150bd3d232d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6523b0ff-c8c5-4eeb-bbd7-b7999c1074bc");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "436ca37a-9d6b-470b-869a-16856172538c", "91a4c558-7e7d-4e68-a2d4-5c736161ac13" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "436ca37a-9d6b-470b-869a-16856172538c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91a4c558-7e7d-4e68-a2d4-5c736161ac13");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6523b0ff-c8c5-4eeb-bbd7-b7999c1074bc", "e18e8213-a99f-4da4-9903-96fad3e76d5a", "User", "USER" },
                    { "62d99878-b51d-408e-8e76-2150bd3d232d", "cc41bfd7-ed91-4221-834d-95d1c34408dc", "Manager", "MANAGER" },
                    { "436ca37a-9d6b-470b-869a-16856172538c", "da4376b2-44a1-468d-a05a-8efd4a1ecfa0", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "91a4c558-7e7d-4e68-a2d4-5c736161ac13", 0, "ab7ffdff-9143-4a53-8ef2-25bba4c927ef", "admin@gmail.com", false, false, null, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEKYV3VhEeQcJZ3dL+b3lIwuSGLC9gxX5NImuC5/B6rEcuswHyNZBULi6A3dT0os7JQ==", null, false, null, "08129ce2-1ec3-4c64-8011-c0aaa3320870", null, false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "436ca37a-9d6b-470b-869a-16856172538c", "91a4c558-7e7d-4e68-a2d4-5c736161ac13" });
        }
    }
}
