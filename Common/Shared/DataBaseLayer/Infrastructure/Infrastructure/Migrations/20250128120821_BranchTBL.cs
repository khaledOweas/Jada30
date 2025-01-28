using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BranchTBL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lookups_Branch_BranchId",
                table: "Lookups");

            migrationBuilder.DropIndex(
                name: "IX_Lookups_BranchId",
                table: "Lookups");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Lookups");

            migrationBuilder.CreateTable(
                name: "BranchComponents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    ComponentId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: true),
                    ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchComponents_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchComponents_Lookups_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchComponents_BranchId",
                table: "BranchComponents",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchComponents_ComponentId",
                table: "BranchComponents",
                column: "ComponentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchComponents");

            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                table: "Lookups",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lookups_BranchId",
                table: "Lookups",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lookups_Branch_BranchId",
                table: "Lookups",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id");
        }
    }
}
