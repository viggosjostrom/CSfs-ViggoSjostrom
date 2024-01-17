using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSfs_ViggoSjöström.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Blogs",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Posts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "Posts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Blogs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
