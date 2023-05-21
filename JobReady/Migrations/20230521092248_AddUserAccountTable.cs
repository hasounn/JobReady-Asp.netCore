using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobReady.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAccountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    About = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccount");
        }
    }
}
