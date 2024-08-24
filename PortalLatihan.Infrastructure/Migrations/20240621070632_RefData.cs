using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalLatihan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "TRAINING",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ZoneID",
                table: "REF_REGION",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "TRAINING");

            migrationBuilder.DropColumn(
                name: "ZoneID",
                table: "REF_REGION");
        }
    }
}
