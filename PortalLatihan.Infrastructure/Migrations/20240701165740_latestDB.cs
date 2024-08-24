using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalLatihan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class latestDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "minParticipant",
                table: "TRAINING_DISCOUNT_GROUP",
                newName: "MinParticipant");

            migrationBuilder.RenameColumn(
                name: "maxParticipant",
                table: "TRAINING_DISCOUNT_GROUP",
                newName: "MaxParticipant");

            migrationBuilder.RenameColumn(
                name: "Fee",
                table: "TRAINING_DISCOUNT_CODE",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "OriginalFee",
                table: "TICKET",
                newName: "TotalFee");

            migrationBuilder.RenameColumn(
                name: "FinalFee",
                table: "TICKET",
                newName: "DiscountedFee");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "TICKET",
                newName: "BaseFee");

            migrationBuilder.RenameColumn(
                name: "ParticipantStatus",
                table: "PARTICIPANT",
                newName: "Status");

            migrationBuilder.AlterColumn<int>(
                name: "MaxParticipant",
                table: "TRAINING_DISCOUNT_GROUP",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainingID",
                table: "TRAINING_DISCOUNT_GROUP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "BalanceQuota",
                table: "TRAINING_DISCOUNT_CODE",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiscountType",
                table: "TRAINING_DISCOUNT_CODE",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredDate",
                table: "TRAINING_DISCOUNT_CODE",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsUsableWithGroupDiscount",
                table: "TRAINING_DISCOUNT_CODE",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DiscountDescription",
                table: "TICKET",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IC",
                table: "PARTICIPANT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TICKET_STATUS_HISTORY",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_TICKET_STATUS_HISTORY", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TICKET_STATUS_HISTORY");

            migrationBuilder.DropColumn(
                name: "TrainingID",
                table: "TRAINING_DISCOUNT_GROUP");

            migrationBuilder.DropColumn(
                name: "BalanceQuota",
                table: "TRAINING_DISCOUNT_CODE");

            migrationBuilder.DropColumn(
                name: "DiscountType",
                table: "TRAINING_DISCOUNT_CODE");

            migrationBuilder.DropColumn(
                name: "ExpiredDate",
                table: "TRAINING_DISCOUNT_CODE");

            migrationBuilder.DropColumn(
                name: "IsUsableWithGroupDiscount",
                table: "TRAINING_DISCOUNT_CODE");

            migrationBuilder.DropColumn(
                name: "DiscountDescription",
                table: "TICKET");

            migrationBuilder.DropColumn(
                name: "IC",
                table: "PARTICIPANT");

            migrationBuilder.RenameColumn(
                name: "MinParticipant",
                table: "TRAINING_DISCOUNT_GROUP",
                newName: "minParticipant");

            migrationBuilder.RenameColumn(
                name: "MaxParticipant",
                table: "TRAINING_DISCOUNT_GROUP",
                newName: "maxParticipant");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "TRAINING_DISCOUNT_CODE",
                newName: "Fee");

            migrationBuilder.RenameColumn(
                name: "TotalFee",
                table: "TICKET",
                newName: "OriginalFee");

            migrationBuilder.RenameColumn(
                name: "DiscountedFee",
                table: "TICKET",
                newName: "FinalFee");

            migrationBuilder.RenameColumn(
                name: "BaseFee",
                table: "TICKET",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "PARTICIPANT",
                newName: "ParticipantStatus");

            migrationBuilder.AlterColumn<int>(
                name: "maxParticipant",
                table: "TRAINING_DISCOUNT_GROUP",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
