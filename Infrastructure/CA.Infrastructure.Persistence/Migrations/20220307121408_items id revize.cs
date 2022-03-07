using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CA.Infrastructure.Persistence.Migrations
{
    public partial class itemsidrevize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_UserID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_UserID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Items");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Items",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Items",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserID",
                table: "Items",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_UserID",
                table: "Items",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");
        }
    }
}
