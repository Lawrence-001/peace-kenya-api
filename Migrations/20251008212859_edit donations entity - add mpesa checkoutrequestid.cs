using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace peace_kenya_api.Migrations
{
    /// <inheritdoc />
    public partial class editdonationsentityaddmpesacheckoutrequestid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "donation_type",
                table: "donations");

            migrationBuilder.AddColumn<string>(
                name: "checkout_request_id",
                table: "donations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "donor_full_name",
                table: "donations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "created_at",
                table: "beneficiaries",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "beneficiaries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "beneficiaries",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "modified_at",
                table: "beneficiaries",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "modified_by",
                table: "beneficiaries",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "checkout_request_id",
                table: "donations");

            migrationBuilder.DropColumn(
                name: "donor_full_name",
                table: "donations");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "beneficiaries");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "beneficiaries");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "beneficiaries");

            migrationBuilder.DropColumn(
                name: "modified_at",
                table: "beneficiaries");

            migrationBuilder.DropColumn(
                name: "modified_by",
                table: "beneficiaries");

            migrationBuilder.AddColumn<int>(
                name: "donation_type",
                table: "donations",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
