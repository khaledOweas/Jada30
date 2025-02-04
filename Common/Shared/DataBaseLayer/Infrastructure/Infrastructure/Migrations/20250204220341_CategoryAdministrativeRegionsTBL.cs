using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CategoryAdministrativeRegionsTBL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoryAdministrativeRegions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdministrativeRegionId = table.Column<long>(type: "bigint", nullable: true),
                    PricingCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: true),
                    ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryAdministrativeRegions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categoryAdministrativeRegions_Lookups_AdministrativeRegionId",
                        column: x => x.AdministrativeRegionId,
                        principalTable: "Lookups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_categoryAdministrativeRegions_PricingCategories_PricingCategoryId",
                        column: x => x.PricingCategoryId,
                        principalTable: "PricingCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_categoryAdministrativeRegions_AdministrativeRegionId",
                table: "categoryAdministrativeRegions",
                column: "AdministrativeRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_categoryAdministrativeRegions_PricingCategoryId",
                table: "categoryAdministrativeRegions",
                column: "PricingCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoryAdministrativeRegions");
        }
    }
}
