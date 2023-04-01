﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationManage.Migrations
{
    /// <inheritdoc />
    public partial class updateproducer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Producer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Producer_UserId",
                table: "Producer",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producer_users_UserId",
                table: "Producer",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producer_users_UserId",
                table: "Producer");

            migrationBuilder.DropIndex(
                name: "IX_Producer_UserId",
                table: "Producer");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Producer");
        }
    }
}
