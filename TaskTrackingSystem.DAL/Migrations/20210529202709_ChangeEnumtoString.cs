using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTrackingSystem.DAL.Migrations
{
    public partial class ChangeEnumtoString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "343c32ed-f71d-46c0-a864-c27d762bedbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ccc9f34-600f-4ecf-bcb1-d45c83971ff7");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "14f0a1bd-4f11-4e1a-a086-202e3ea8dc34", "41870281-9f68-4d13-9c32-0ca9ab0a8416" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14f0a1bd-4f11-4e1a-a086-202e3ea8dc34");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41870281-9f68-4d13-9c32-0ca9ab0a8416");

            migrationBuilder.AlterColumn<string>(
                name: "Progress",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67819482-a3b6-46fd-a7f3-2f922e6517dc", "54cf493e-729f-4352-8b2c-ea9e8720f6c9", "User", "USER" },
                    { "bdc1025c-ee6b-4131-8625-16006336dc5b", "9285663f-0abb-42c4-82a0-afed5cd69649", "Manager", "MANAGER" },
                    { "3cbdeb58-315d-46d6-8ee2-4f65bf9b2c50", "c2541e66-bd13-40cc-bb62-573f1e501979", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "28f9cd10-29b1-4bb6-a9ad-7f84853fb346", 0, "b0ed7e4e-a071-447f-96ab-6ab658b3d744", "admin@gmail.com", false, false, null, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEOtggh9+i8fSAWiXnF0IE73g/Ai/PIJE5flvltdYjSIDwpCejoNHvpXs5jaoAsCnLw==", null, false, null, "97e018cd-6473-46b0-85e7-9192b6e3845e", null, false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3cbdeb58-315d-46d6-8ee2-4f65bf9b2c50", "28f9cd10-29b1-4bb6-a9ad-7f84853fb346" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67819482-a3b6-46fd-a7f3-2f922e6517dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdc1025c-ee6b-4131-8625-16006336dc5b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3cbdeb58-315d-46d6-8ee2-4f65bf9b2c50", "28f9cd10-29b1-4bb6-a9ad-7f84853fb346" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cbdeb58-315d-46d6-8ee2-4f65bf9b2c50");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "28f9cd10-29b1-4bb6-a9ad-7f84853fb346");

            migrationBuilder.AlterColumn<int>(
                name: "Progress",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ccc9f34-600f-4ecf-bcb1-d45c83971ff7", "d159afda-bda6-4e1e-80a7-6445498cbda5", "User", "USER" },
                    { "343c32ed-f71d-46c0-a864-c27d762bedbd", "b2893093-af7b-4719-adab-611cf9757c5a", "Manager", "MANAGER" },
                    { "14f0a1bd-4f11-4e1a-a086-202e3ea8dc34", "02414c85-4da7-4919-8c25-4ed5aaa715f1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "41870281-9f68-4d13-9c32-0ca9ab0a8416", 0, "dec2a6d7-040b-4387-b0a4-937be6132cac", "admin@gmail.com", false, false, null, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEPj216XR0zG3etWrNpWtosjkXthdy5qQM/GwZp/COLl3s9rrQU/UOimGhEz8uBlsyA==", null, false, 0, "fa1dd3f3-5545-4f5e-917a-2f95ee093f55", null, false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "14f0a1bd-4f11-4e1a-a086-202e3ea8dc34", "41870281-9f68-4d13-9c32-0ca9ab0a8416" });
        }
    }
}
