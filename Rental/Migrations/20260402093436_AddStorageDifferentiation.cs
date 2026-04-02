using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rental.Migrations
{
    /// <inheritdoc />
    public partial class AddStorageDifferentiation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Garages_GarageId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Garages");

            migrationBuilder.DropTable(
                name: "GarageTypes");

            migrationBuilder.RenameColumn(
                name: "Income",
                table: "VehicleTypes",
                newName: "MonthlyIncome");

            migrationBuilder.RenameColumn(
                name: "Income",
                table: "Vehicles",
                newName: "MonthlyIncome");

            migrationBuilder.RenameColumn(
                name: "GarageId",
                table: "Vehicles",
                newName: "StorageId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_GarageId",
                table: "Vehicles",
                newName: "IX_Vehicles_StorageId");

            migrationBuilder.AddColumn<string>(
                name: "RequiredStorageType",
                table: "VehicleTypes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "StorageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    MonthlyCosts = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    MonthlyCosts = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storages_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Storages_StorageTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "StorageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StorageTypes",
                columns: new[] { "Id", "Capacity", "Category", "MonthlyCosts", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 5, "Garage", 1000m, "Small Garage", 10000m },
                    { 2, 15, "Garage", 3000m, "Large Garage", 30000m },
                    { 3, 10, "Garage", 2000m, "Medium Garage", 200000m }
                });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "RequiredStorageType",
                value: "Garage");

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "RequiredStorageType",
                value: "Garage");

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "RequiredStorageType",
                value: "Garage");

            migrationBuilder.CreateIndex(
                name: "IX_Storages_CompanyId",
                table: "Storages",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Storages_TypeId",
                table: "Storages",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Storages_StorageId",
                table: "Vehicles",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Storages_StorageId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "StorageTypes");

            migrationBuilder.DropColumn(
                name: "RequiredStorageType",
                table: "VehicleTypes");

            migrationBuilder.RenameColumn(
                name: "MonthlyIncome",
                table: "VehicleTypes",
                newName: "Income");

            migrationBuilder.RenameColumn(
                name: "StorageId",
                table: "Vehicles",
                newName: "GarageId");

            migrationBuilder.RenameColumn(
                name: "MonthlyIncome",
                table: "Vehicles",
                newName: "Income");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_StorageId",
                table: "Vehicles",
                newName: "IX_Vehicles_GarageId");

            migrationBuilder.CreateTable(
                name: "GarageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Costs = table.Column<decimal>(type: "numeric", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Costs = table.Column<decimal>(type: "numeric", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Garages_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Garages_GarageTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "GarageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GarageTypes",
                columns: new[] { "Id", "Capacity", "Costs", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 5, 1000m, "Small Garage", 10000m },
                    { 2, 15, 4000m, "Medium Garage", 20000m },
                    { 3, 30, 10000m, "Large Garage", 50000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Garages_CompanyId",
                table: "Garages",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Garages_TypeId",
                table: "Garages",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Garages_GarageId",
                table: "Vehicles",
                column: "GarageId",
                principalTable: "Garages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
