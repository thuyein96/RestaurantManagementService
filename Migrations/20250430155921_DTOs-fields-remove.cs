using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManagementService.Migrations
{
    /// <inheritdoc />
    public partial class DTOsfieldsremove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Tables");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "TimeSlots",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Tables",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
