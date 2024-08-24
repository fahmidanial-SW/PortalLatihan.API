using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalLatihan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Ticket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountDescription",
                table: "TICKET");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "TICKET");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "TICKET",
                newName: "FinalFee");

            migrationBuilder.RenameColumn(
                name: "BaseFee",
                table: "TICKET",
                newName: "DiscountGroup");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountCode",
                table: "TICKET",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountCode",
                table: "TICKET");

            migrationBuilder.RenameColumn(
                name: "FinalFee",
                table: "TICKET",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "DiscountGroup",
                table: "TICKET",
                newName: "BaseFee");

            migrationBuilder.AddColumn<string>(
                name: "DiscountDescription",
                table: "TICKET",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "TICKET",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
