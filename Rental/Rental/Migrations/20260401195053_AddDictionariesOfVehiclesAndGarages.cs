using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rental.Migrations
{
    /// <inheritdoc />
    public partial class AddDictionariesOfVehiclesAndGarages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Garages");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Vehicles",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Income",
                table: "Vehicles",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Vehicles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Garages",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Costs",
                table: "Garages",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Garages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Company",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "GarageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Costs = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<string>(type: "text", nullable: false),
                    Income = table.Column<decimal>(type: "numeric", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Category", "Income", "Level", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Car", 500m, "Economy", "Economy Car", 5000m },
                    { 2, "Car", 1000m, "Comfort", "Comfort Car", 10000m },
                    { 3, "Car", 3000m, "Business", "Business Car", 20000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TypeId",
                table: "Vehicles",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Garages_TypeId",
                table: "Garages",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_GarageTypes_TypeId",
                table: "Garages",
                column: "TypeId",
                principalTable: "GarageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_TypeId",
                table: "Vehicles",
                column: "TypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garages_GarageTypes_TypeId",
                table: "Garages");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_TypeId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "GarageTypes");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_TypeId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Garages_TypeId",
                table: "Garages");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Garages");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Vehicles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Income",
                table: "Vehicles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Vehicles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Garages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Costs",
                table: "Garages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Garages",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Balance",
                table: "Company",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
