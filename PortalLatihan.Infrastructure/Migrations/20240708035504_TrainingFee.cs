using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalLatihan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TrainingFee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountedFee",
                table: "TICKET",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "IC",
                table: "PARTICIPANT",
                newName: "Phone");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "TRAINING_STATUS_HISTORY",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DiscountType",
                table: "TRAINING_DISCOUNT_GROUP",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DiscountType",
                table: "TRAINING_DISCOUNT_CODE",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "MaxDiscount",
                table: "TRAINING_DISCOUNT_CODE",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TRAINING",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TICKET_STATUS_HISTORY",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "TICKET_STATUS_HISTORY",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TICKET",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerType",
                table: "TICKET",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PARTICIPANT",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PARTICIPANT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentityNum",
                table: "PARTICIPANT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentityType",
                table: "PARTICIPANT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainingFeeID",
                table: "PARTICIPANT",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TRAINING_FEE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SysUserCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SysUserModified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAINING_FEE", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRAINING_FEE");

            migrationBuilder.DropColumn(
                name: "MaxDiscount",
                table: "TRAINING_DISCOUNT_CODE");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "PARTICIPANT");

            migrationBuilder.DropColumn(
                name: "IdentityNum",
                table: "PARTICIPANT");

            migrationBuilder.DropColumn(
                name: "IdentityType",
                table: "PARTICIPANT");

            migrationBuilder.DropColumn(
                name: "TrainingFeeID",
                table: "PARTICIPANT");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "TICKET",
                newName: "DiscountedFee");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "PARTICIPANT",
                newName: "IC");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "TRAINING_STATUS_HISTORY",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiscountType",
                table: "TRAINING_DISCOUNT_GROUP",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountType",
                table: "TRAINING_DISCOUNT_CODE",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "TRAINING",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "TICKET_STATUS_HISTORY",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "TICKET_STATUS_HISTORY",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "TICKET",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerType",
                table: "TICKET",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "PARTICIPANT",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
