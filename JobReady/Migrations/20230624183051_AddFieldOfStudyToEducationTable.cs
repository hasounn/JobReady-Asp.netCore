using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobReady.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldOfStudyToEducationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FieldOfStudy",
                table: "Education",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldOfStudy",
                table: "Education");
        }
    }
}
