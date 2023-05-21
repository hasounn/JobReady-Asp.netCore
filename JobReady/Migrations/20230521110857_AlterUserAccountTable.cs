using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobReady.Migrations
{
    /// <inheritdoc />
    public partial class AlterUserAccountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IndustryId",
                table: "UserAccounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_IndustryId",
                table: "UserAccounts",
                column: "IndustryId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_Industries_IndustryId",
                table: "UserAccounts",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_Industries_IndustryId",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_IndustryId",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "IndustryId",
                table: "UserAccounts");
        }
    }
}
