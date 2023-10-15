using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IbgeApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email_EmailAddress = table.Column<string>(type: "nvarchar", maxLength: 80, nullable: false),
                    Name_FirstName = table.Column<string>(type: "nvarchar", maxLength: 80, nullable: false),
                    PasswordHash_Hash = table.Column<string>(type: "nvarchar", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
