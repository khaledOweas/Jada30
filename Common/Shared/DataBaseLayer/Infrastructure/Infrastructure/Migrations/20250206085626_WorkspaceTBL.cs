using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WorkspaceTBL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "workspaceSubcategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkspaceCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WithTax = table.Column<bool>(type: "bit", nullable: false),
                    DefaultContractType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasicPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsShared = table.Column<bool>(type: "bit", nullable: false),
                    SubscriptionMechanism = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: true),
                    ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workspaceSubcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workspaceSubcategories_Lookups_WorkspaceCategoryId",
                        column: x => x.WorkspaceCategoryId,
                        principalTable: "Lookups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "workspacePriceCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkspaceSubcategoryId = table.Column<long>(type: "bigint", nullable: true),
                    PriceCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: true),
                    ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workspacePriceCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workspacePriceCategories_workspaceSubcategories_WorkspaceSubcategoryId",
                        column: x => x.WorkspaceSubcategoryId,
                        principalTable: "workspaceSubcategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "workspaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkspaceCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    WorkspaceSubcategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    IsSubcategoryShared = table.Column<bool>(type: "bit", nullable: false),
                    InternalOrView = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: true),
                    ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workspaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workspaces_Lookups_WorkspaceCategoryId",
                        column: x => x.WorkspaceCategoryId,
                        principalTable: "Lookups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_workspaces_workspaceSubcategories_WorkspaceSubcategoryId",
                        column: x => x.WorkspaceSubcategoryId,
                        principalTable: "workspaceSubcategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_workspacePriceCategories_WorkspaceSubcategoryId",
                table: "workspacePriceCategories",
                column: "WorkspaceSubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_workspaces_WorkspaceCategoryId",
                table: "workspaces",
                column: "WorkspaceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_workspaces_WorkspaceSubcategoryId",
                table: "workspaces",
                column: "WorkspaceSubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_workspaceSubcategories_WorkspaceCategoryId",
                table: "workspaceSubcategories",
                column: "WorkspaceCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workspacePriceCategories");

            migrationBuilder.DropTable(
                name: "workspaces");

            migrationBuilder.DropTable(
                name: "workspaceSubcategories");
        }
    }
}
