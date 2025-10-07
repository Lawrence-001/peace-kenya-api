using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace peace_kenya_api.Migrations
{
    /// <inheritdoc />
    public partial class editbeneficiaryfirstnamecorrectly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fisrt_name",
                table: "beneficiaries",
                newName: "first_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "beneficiaries",
                newName: "fisrt_name");
        }
    }
}
