using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenPrint.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Password", "Roleid" },
                values: new object[] { "alex802c@gmail.com", "Pwrvol901", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Password", "Roleid" },
                values: new object[] { "JohnnyD@69420.com", "Password", 1 });
        }
    }
}
