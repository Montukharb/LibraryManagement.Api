using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class LibraryBooks2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LibraryBooks",
                columns: new[] { "BookId", "Name", "Price", "PublisherId", "PublisherName", "Title" },
                values: new object[] { 1, "Lucent", 300, 89521, "GovtPublicationHouse", "Gk Book" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LibraryBooks",
                keyColumn: "BookId",
                keyValue: 1);
        }
    }
}
