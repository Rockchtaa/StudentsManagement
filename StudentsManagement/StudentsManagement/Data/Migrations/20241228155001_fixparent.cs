using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsManagement.Migrations
{
    /// <inheritdoc />
    public partial class fixparent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Parents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
