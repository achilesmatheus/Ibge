using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IbgeApi.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name_LastName",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name_LastName",
                table: "Users",
                type: "nvarchar",
                maxLength: 80,
                nullable: false,
                defaultValue: "");
        }
    }
}
