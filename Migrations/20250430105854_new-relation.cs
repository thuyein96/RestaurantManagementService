using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManagementService.Migrations
{
    /// <inheritdoc />
    public partial class newrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Bookings_BookingsId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Bookings_BookingsId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_Bookings_BookingsId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_BookingsId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_Tables_BookingsId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Customers_BookingsId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BookingsId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "BookingsId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "BookingsId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "BookingSlotId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingSlotId",
                table: "Bookings",
                column: "BookingSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TableId",
                table: "Bookings",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tables_TableId",
                table: "Bookings",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_TimeSlots_BookingSlotId",
                table: "Bookings",
                column: "BookingSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Tables_TableId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_TimeSlots_BookingSlotId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BookingSlotId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_TableId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingSlotId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "BookingsId",
                table: "TimeSlots",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingsId",
                table: "Tables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingsId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_BookingsId",
                table: "TimeSlots",
                column: "BookingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_BookingsId",
                table: "Tables",
                column: "BookingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BookingsId",
                table: "Customers",
                column: "BookingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Bookings_BookingsId",
                table: "Customers",
                column: "BookingsId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Bookings_BookingsId",
                table: "Tables",
                column: "BookingsId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_Bookings_BookingsId",
                table: "TimeSlots",
                column: "BookingsId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }
    }
}
