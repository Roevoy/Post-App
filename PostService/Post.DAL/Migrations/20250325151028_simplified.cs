using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POST.DAL.Migrations
{
    /// <inheritdoc />
    public partial class simplified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_Shipment_ShipmentId",
                table: "Boxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Clients_ReceiverId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Clients_SenderId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Destinations_DepartmentId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Destinations_DepartmentSenderId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Destinations_DestinationId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Destinations_ParcelLockerId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Slots_Destinations_ParcelLockerId",
                table: "Slots");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_City_Street",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slots",
                table: "Slots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shipment",
                table: "Shipment");

            migrationBuilder.DropIndex(
                name: "IX_Shipment_DepartmentId",
                table: "Shipment");

            migrationBuilder.DropIndex(
                name: "IX_Shipment_ParcelLockerId",
                table: "Shipment");

            migrationBuilder.DropIndex(
                name: "IX_Shipment_ReceiverId",
                table: "Shipment");

            migrationBuilder.DropIndex(
                name: "IX_Shipment_SenderId",
                table: "Shipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boxes",
                table: "Boxes");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "ParcelLockerId",
                table: "Shipment");

            migrationBuilder.RenameTable(
                name: "Slots",
                newName: "Slot");

            migrationBuilder.RenameTable(
                name: "Shipment",
                newName: "Shipments");

            migrationBuilder.RenameTable(
                name: "Boxes",
                newName: "Box");

            migrationBuilder.RenameColumn(
                name: "isAvailable",
                table: "Destinations",
                newName: "IsAvailable");

            migrationBuilder.RenameColumn(
                name: "isAvailable",
                table: "Slot",
                newName: "IsOpen");

            migrationBuilder.RenameIndex(
                name: "IX_Slots_ParcelLockerId",
                table: "Slot",
                newName: "IX_Slot_ParcelLockerId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipment_DestinationId",
                table: "Shipments",
                newName: "IX_Shipments_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipment_DepartmentSenderId",
                table: "Shipments",
                newName: "IX_Shipments_DepartmentSenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Boxes_ShipmentId",
                table: "Box",
                newName: "IX_Box_ShipmentId");

            migrationBuilder.AddColumn<Guid>(
                name: "RecipientId",
                table: "Destinations",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Slot",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentId",
                table: "Slot",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ReceiverId",
                table: "Shipments",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Shipments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slot",
                table: "Slot",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shipments",
                table: "Shipments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Box",
                table: "Box",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Box_Shipments_ShipmentId",
                table: "Box",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Destinations_DepartmentSenderId",
                table: "Shipments",
                column: "DepartmentSenderId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Destinations_DestinationId",
                table: "Shipments",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Slot_Destinations_ParcelLockerId",
                table: "Slot",
                column: "ParcelLockerId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Box_Shipments_ShipmentId",
                table: "Box");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Destinations_DepartmentSenderId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Destinations_DestinationId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Slot_Destinations_ParcelLockerId",
                table: "Slot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slot",
                table: "Slot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shipments",
                table: "Shipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Box",
                table: "Box");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Slot");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "Slot");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Shipments");

            migrationBuilder.RenameTable(
                name: "Slot",
                newName: "Slots");

            migrationBuilder.RenameTable(
                name: "Shipments",
                newName: "Shipment");

            migrationBuilder.RenameTable(
                name: "Box",
                newName: "Boxes");

            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "Destinations",
                newName: "isAvailable");

            migrationBuilder.RenameColumn(
                name: "IsOpen",
                table: "Slots",
                newName: "isAvailable");

            migrationBuilder.RenameIndex(
                name: "IX_Slot_ParcelLockerId",
                table: "Slots",
                newName: "IX_Slots_ParcelLockerId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipments_DestinationId",
                table: "Shipment",
                newName: "IX_Shipment_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipments_DepartmentSenderId",
                table: "Shipment",
                newName: "IX_Shipment_DepartmentSenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Box_ShipmentId",
                table: "Boxes",
                newName: "IX_Boxes_ShipmentId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReceiverId",
                table: "Shipment",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Shipment",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParcelLockerId",
                table: "Shipment",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slots",
                table: "Slots",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shipment",
                table: "Shipment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boxes",
                table: "Boxes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    SecondName = table.Column<string>(type: "text", nullable: false),
                    ThirdName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    SecondName = table.Column<string>(type: "text", nullable: false),
                    ThirdName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Destinations_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_City_Street",
                table: "Addresses",
                columns: new[] { "City", "Street" });

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_DepartmentId",
                table: "Shipment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_ParcelLockerId",
                table: "Shipment",
                column: "ParcelLockerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_ReceiverId",
                table: "Shipment",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_SenderId",
                table: "Shipment",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_FirstName_SecondName",
                table: "Clients",
                columns: new[] { "FirstName", "SecondName" });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Phone",
                table: "Clients",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_FirstName_SecondName",
                table: "Employees",
                columns: new[] { "FirstName", "SecondName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_Shipment_ShipmentId",
                table: "Boxes",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Clients_ReceiverId",
                table: "Shipment",
                column: "ReceiverId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Clients_SenderId",
                table: "Shipment",
                column: "SenderId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Destinations_DepartmentId",
                table: "Shipment",
                column: "DepartmentId",
                principalTable: "Destinations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Destinations_DepartmentSenderId",
                table: "Shipment",
                column: "DepartmentSenderId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Destinations_DestinationId",
                table: "Shipment",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Destinations_ParcelLockerId",
                table: "Shipment",
                column: "ParcelLockerId",
                principalTable: "Destinations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Slots_Destinations_ParcelLockerId",
                table: "Slots",
                column: "ParcelLockerId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
