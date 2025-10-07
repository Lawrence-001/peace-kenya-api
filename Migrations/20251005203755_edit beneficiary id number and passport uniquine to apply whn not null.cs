using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace peace_kenya_api.Migrations
{
    /// <inheritdoc />
    public partial class editbeneficiaryidnumberandpassportuniquinetoapplywhnnotnull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_beneficiaries_id_number",
                table: "beneficiaries");

            migrationBuilder.DropIndex(
                name: "ix_beneficiaries_passport_number",
                table: "beneficiaries");

            migrationBuilder.CreateIndex(
                name: "ix_beneficiaries_id_number",
                table: "beneficiaries",
                column: "id_number",
                unique: true,
                filter: "\"id_number\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_beneficiaries_passport_number",
                table: "beneficiaries",
                column: "passport_number",
                unique: true,
                filter: "\"passport_number\" IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_beneficiaries_id_number",
                table: "beneficiaries");

            migrationBuilder.DropIndex(
                name: "ix_beneficiaries_passport_number",
                table: "beneficiaries");

            migrationBuilder.CreateIndex(
                name: "ix_beneficiaries_id_number",
                table: "beneficiaries",
                column: "id_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_beneficiaries_passport_number",
                table: "beneficiaries",
                column: "passport_number",
                unique: true);
        }
    }
}
