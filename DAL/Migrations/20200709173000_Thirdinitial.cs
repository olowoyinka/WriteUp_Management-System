using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Thirdinitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Topics_TopicsId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_TopicsId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "TopicsId",
                table: "Notifications");

            migrationBuilder.AddColumn<Guid>(
                name: "Url",
                table: "Notifications",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Notifications");

            migrationBuilder.AddColumn<Guid>(
                name: "TopicsId",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TopicsId",
                table: "Notifications",
                column: "TopicsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Topics_TopicsId",
                table: "Notifications",
                column: "TopicsId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
