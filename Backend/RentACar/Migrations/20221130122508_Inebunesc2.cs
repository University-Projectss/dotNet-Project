using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACar.Migrations
{
    /// <inheritdoc />
    public partial class Inebunesc2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "UsersTable");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "OfficesTable");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "LocationsTable");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "JobsTable");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "CarsTable");

            migrationBuilder.AlterColumn<int>(
                name: "RoleName",
                table: "UsersTable",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "UsersTable",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "UsersTable",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "OfficesTable",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "LocationsTable",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "JobsTable",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "CarsTable",
                type: "datetime2",
                nullable: true);
        }
    }
}
