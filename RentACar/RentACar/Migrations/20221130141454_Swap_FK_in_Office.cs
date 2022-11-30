using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACar.Migrations
{
    /// <inheritdoc />
    public partial class SwapFKinOffice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationsTable_OfficesTable_OfficeId",
                table: "LocationsTable");

            migrationBuilder.DropIndex(
                name: "IX_LocationsTable_OfficeId",
                table: "LocationsTable");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "LocationsTable");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "OfficesTable",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OfficesTable_LocationId",
                table: "OfficesTable",
                column: "LocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficesTable_LocationsTable_LocationId",
                table: "OfficesTable",
                column: "LocationId",
                principalTable: "LocationsTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficesTable_LocationsTable_LocationId",
                table: "OfficesTable");

            migrationBuilder.DropIndex(
                name: "IX_OfficesTable_LocationId",
                table: "OfficesTable");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "OfficesTable");

            migrationBuilder.AddColumn<Guid>(
                name: "OfficeId",
                table: "LocationsTable",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LocationsTable_OfficeId",
                table: "LocationsTable",
                column: "OfficeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationsTable_OfficesTable_OfficeId",
                table: "LocationsTable",
                column: "OfficeId",
                principalTable: "OfficesTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
