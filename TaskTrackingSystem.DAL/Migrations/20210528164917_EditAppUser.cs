using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTrackingSystem.DAL.Migrations
{
    public partial class EditAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83c75af3-8539-4974-aba7-c4787f5c48d1", "e3670781-90bf-475a-9282-3eca540d8f0e", "User", "USER" },
                    { "0ad691b1-0002-4833-bc10-18e991ee0e96", "4141bb52-3008-42c5-816f-c6a0c559657b", "Manager", "MANAGER" },
                    { "29530321-3970-4761-8178-1ab45f85c514", "1a8834a2-ba60-43b1-b186-31c1682be101", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2102f2fb-abe1-450c-b76b-008f610e0a4e", 0, "db8ab71a-74c9-45e9-9f8b-a3a568a6605c", "admin@gmail.com", false, false, null, null, null, "ADMIN", "AQAAAAEAACcQAAAAEMVJOPJEPoNkICPftoVJuMc62ea+qFd8RMaVO18vSAG1+Nj4GDrBny/QXE3e8TVd/Q==", null, false, "e1f8f83e-cd8e-4ec5-88f2-2a1a220a72e7", null, false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "29530321-3970-4761-8178-1ab45f85c514", "2102f2fb-abe1-450c-b76b-008f610e0a4e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ad691b1-0002-4833-bc10-18e991ee0e96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83c75af3-8539-4974-aba7-c4787f5c48d1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "29530321-3970-4761-8178-1ab45f85c514", "2102f2fb-abe1-450c-b76b-008f610e0a4e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29530321-3970-4761-8178-1ab45f85c514");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2102f2fb-abe1-450c-b76b-008f610e0a4e");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

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
    }
}
