using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleCodeFirstDatabaseClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainAddressId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondAddressId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_People_MainAddressId",
                table: "People",
                column: "MainAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_People_SecondAddressId",
                table: "People",
                column: "SecondAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Addresses_MainAddressId",
                table: "People",
                column: "MainAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Addresses_SecondAddressId",
                table: "People",
                column: "SecondAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Addresses_MainAddressId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Addresses_SecondAddressId",
                table: "People");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_People_MainAddressId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_SecondAddressId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "MainAddressId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "SecondAddressId",
                table: "People");
        }
    }
}
