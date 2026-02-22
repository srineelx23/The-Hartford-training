using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentMgmt.Migrations
{
    /// <inheritdoc />
    public partial class added_trainername_in_feedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrainerName",
                table: "StudentFeedback",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainerName",
                table: "StudentFeedback");
        }
    }
}
