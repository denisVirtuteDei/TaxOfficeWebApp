using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxOfficeWebApp.Migrations
{
    public partial class IsCorrectProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "PayedTaxes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "BankChecks",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "PayedTaxes");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "BankChecks");
        }
    }
}
