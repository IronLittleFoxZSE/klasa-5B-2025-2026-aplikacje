using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleCodeFirstDatabaseClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddCountryToPeople : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "People",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "People");
        }
    }
}
