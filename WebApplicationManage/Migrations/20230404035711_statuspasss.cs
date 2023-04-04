using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationManage.Migrations
{
    /// <inheritdoc />
    public partial class statuspasss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "Order",
                newName: "FullName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Order",
                newName: "Fullname");
        }
    }
}
