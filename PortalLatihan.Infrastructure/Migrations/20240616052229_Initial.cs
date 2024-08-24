using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalLatihan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PARTICIPANT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipantStatus = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SysUserCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SysUserModified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARTICIPANT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "REF_REGION",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SysUserCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SysUserModified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REF_REGION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "REF_ZONE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SysUserCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SysUserModified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REF_ZONE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TICKET",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingDiscountCodeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrainingDiscountGroupID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BuyerType = table.Column<int>(type: "int", nullable: false),
                    BuyerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OriginalFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinalFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SysUserCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SysUserModified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TICKET", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TRAINING",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZoneID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationInDays = table.Column<int>(type: "int", nullable: false),
                    MinParticipant = table.Column<int>(type: "int", nullable: false),
                    MaxParticipant = table.Column<int>(type: "int", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SysUserCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SysUserModified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAINING", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TRAINING_DISCOUNT_CODE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quota = table.Column<int>(type: "int", nullable: false),
                    TrainingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SysUserCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SysUserModified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAINING_DISCOUNT_CODE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TRAINING_DISCOUNT_GROUP",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    minParticipant = table.Column<int>(type: "int", nullable: false),
                    maxParticipant = table.Column<int>(type: "int", nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SysUserCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SysUserModified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAINING_DISCOUNT_GROUP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TRAINING_STATUS_HISTORY",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SysUserCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SysUserModified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAINING_STATUS_HISTORY", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PARTICIPANT");

            migrationBuilder.DropTable(
                name: "REF_REGION");

            migrationBuilder.DropTable(
                name: "REF_ZONE");

            migrationBuilder.DropTable(
                name: "TICKET");

            migrationBuilder.DropTable(
                name: "TRAINING");

            migrationBuilder.DropTable(
                name: "TRAINING_DISCOUNT_CODE");

            migrationBuilder.DropTable(
                name: "TRAINING_DISCOUNT_GROUP");

            migrationBuilder.DropTable(
                name: "TRAINING_STATUS_HISTORY");
        }
    }
}
