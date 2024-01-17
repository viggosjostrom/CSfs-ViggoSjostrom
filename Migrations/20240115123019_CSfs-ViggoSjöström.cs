using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSfs_ViggoSjöström.Migrations
{
    /// <inheritdoc />
    public partial class CSfsViggoSjöström : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
