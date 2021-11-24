using Microsoft.EntityFrameworkCore.Migrations;

namespace in_and_out.Migrations
{
    public partial class ChangeExpenseID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Expenses",
                newName: "ExpenseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpenseId",
                table: "Expenses",
                newName: "MyProperty");
        }
    }
}
