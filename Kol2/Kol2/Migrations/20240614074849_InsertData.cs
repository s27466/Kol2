using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kol2.Migrations
{
    /// <inheritdoc />
    public partial class InsertData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "IdClient", "FirstName", "LastName", "Email", "Phone" },
                values: new object[] { 1, "John", "Doe", "john.doe@example.com", "1234567890" }
            );

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "IdClient", "FirstName", "LastName", "Email", "Phone" },
                values: new object[] { 2, "Jane", "Doe", "jane.doe@example.com", "0987654321" }
            );

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "IdSubscription", "Name", "Amount", "RenewalPeriod", "CreatedAt", "EndDate", "ClientId" },
                values: new object[] { 1, "Monthly Subscription", 10.00m, 1, DateTime.UtcNow, null, 1 }
            );

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "IdSubscription", "Name", "Amount", "RenewalPeriod", "CreatedAt", "EndDate", "ClientId" },
                values: new object[] { 2, "Yearly Subscription", 100.00m, 12, DateTime.UtcNow, null, 2 }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "IdClient",
                keyValue: 1
            );

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "IdClient",
                keyValue: 2
            );

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "IdSubcription",
                keyValue: 1
            );

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "IdSubscription",
                keyValue: 2
            );
        }
    }
}
