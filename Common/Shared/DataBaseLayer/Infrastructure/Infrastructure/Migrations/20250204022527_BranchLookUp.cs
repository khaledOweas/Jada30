using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BranchLookUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "WebsiteBranchId",
                table: "Branch",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CategoryBranchId",
                table: "Branch",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AdministrativeRegionId",
                table: "Branch",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            //migrationBuilder.CreateTable(
            //    name: "SupportingServiceProvider",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        SpecializationId = table.Column<long>(type: "bigint", nullable: true),
            //        NationalityId = table.Column<long>(type: "bigint", nullable: true),
            //        Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        WebsiteURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsJadah30Restricted = table.Column<bool>(type: "bit", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        CreatedBy = table.Column<int>(type: "int", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ModifyBy = table.Column<int>(type: "int", nullable: true),
            //        ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SupportingServiceProvider", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_SupportingServiceProvider_Lookups_NationalityId",
            //            column: x => x.NationalityId,
            //            principalTable: "Lookups",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_SupportingServiceProvider_Lookups_SpecializationId",
            //            column: x => x.SpecializationId,
            //            principalTable: "Lookups",
            //            principalColumn: "Id");
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_AdministrativeRegionId",
                table: "Branch",
                column: "AdministrativeRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CategoryBranchId",
                table: "Branch",
                column: "CategoryBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_WebsiteBranchId",
                table: "Branch",
                column: "WebsiteBranchId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SupportingServiceProvider_NationalityId",
            //    table: "SupportingServiceProvider",
            //    column: "NationalityId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SupportingServiceProvider_SpecializationId",
            //    table: "SupportingServiceProvider",
            //    column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Lookups_AdministrativeRegionId",
                table: "Branch",
                column: "AdministrativeRegionId",
                principalTable: "Lookups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Lookups_CategoryBranchId",
                table: "Branch",
                column: "CategoryBranchId",
                principalTable: "Lookups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Lookups_WebsiteBranchId",
                table: "Branch",
                column: "WebsiteBranchId",
                principalTable: "Lookups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Lookups_AdministrativeRegionId",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Lookups_CategoryBranchId",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Lookups_WebsiteBranchId",
                table: "Branch");

            migrationBuilder.DropTable(
                name: "SupportingServiceProvider");

            migrationBuilder.DropIndex(
                name: "IX_Branch_AdministrativeRegionId",
                table: "Branch");

            migrationBuilder.DropIndex(
                name: "IX_Branch_CategoryBranchId",
                table: "Branch");

            migrationBuilder.DropIndex(
                name: "IX_Branch_WebsiteBranchId",
                table: "Branch");

            migrationBuilder.AlterColumn<long>(
                name: "WebsiteBranchId",
                table: "Branch",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CategoryBranchId",
                table: "Branch",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AdministrativeRegionId",
                table: "Branch",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
