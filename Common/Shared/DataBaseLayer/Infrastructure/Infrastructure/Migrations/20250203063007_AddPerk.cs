using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPerk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perk",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsTaxIncluded = table.Column<bool>(type: "bit", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    IsForJadah30Customers = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: true),
                    ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerkLicense",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerkId = table.Column<long>(type: "bigint", nullable: false),
                    LicenseId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: true),
                    ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerkLicense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerkLicense_Lookups_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerkLicense_Perk_PerkId",
                        column: x => x.PerkId,
                        principalTable: "Perk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerkLicense_LicenseId",
                table: "PerkLicense",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_PerkLicense_PerkId",
                table: "PerkLicense",
                column: "PerkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerkLicense");

            migrationBuilder.DropTable(
                name: "Perk");
        }
    }
}
