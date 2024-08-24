using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalLatihan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ParticipantIsAttended : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAttended",
                table: "PARTICIPANT",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAttended",
                table: "PARTICIPANT");
        }
    }
}
