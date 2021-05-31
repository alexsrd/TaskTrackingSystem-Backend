using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTrackingSystem.DAL.Migrations
{
    public partial class ApplyManyToManyUserProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProject_AspNetUsers_UserId",
                table: "UserProject");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProject_Projects_ProjectId",
                table: "UserProject");

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

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserProject",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "UserProject",
                newName: "ProjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProject_UserId",
                table: "UserProject",
                newName: "IX_UserProject_UsersId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserProject_AspNetUsers_UsersId",
                table: "UserProject",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProject_Projects_ProjectsId",
                table: "UserProject",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProject_AspNetUsers_UsersId",
                table: "UserProject");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProject_Projects_ProjectsId",
                table: "UserProject");

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

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "UserProject",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ProjectsId",
                table: "UserProject",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProject_UsersId",
                table: "UserProject",
                newName: "IX_UserProject_UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserProject_AspNetUsers_UserId",
                table: "UserProject",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProject_Projects_ProjectId",
                table: "UserProject",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
