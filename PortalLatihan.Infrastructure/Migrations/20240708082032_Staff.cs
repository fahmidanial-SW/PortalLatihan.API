using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalLatihan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Staff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "STAFF",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SysUserCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SysUserModified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STAFF", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STAFF");
        }
    }
}
