using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReplyFlow.Migrations
{
    /// <inheritdoc />
    public partial class updateUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordResetToken",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PasswordResetTokenExpiryUtc",
                table: "Users",
                newName: "ResetCodeExpiryUtc");

            migrationBuilder.AddColumn<string>(
                name: "ResetCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResetCode",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ResetCodeExpiryUtc",
                table: "Users",
                newName: "PasswordResetTokenExpiryUtc");

            migrationBuilder.AddColumn<string>(
                name: "PasswordResetToken",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
