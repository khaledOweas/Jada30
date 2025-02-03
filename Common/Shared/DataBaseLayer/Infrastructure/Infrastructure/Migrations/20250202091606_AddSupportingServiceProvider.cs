using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSupportingServiceProvider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupportingServiceProvider",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecializationId = table.Column<long>(type: "bigint", nullable: true),
                    NationalityId = table.Column<long>(type: "bigint", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebsiteURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsJadah30Restricted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: true),
                    ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportingServiceProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportingServiceProvider_Lookups_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Lookups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupportingServiceProvider_Lookups_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Lookups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupportingServiceProvider_NationalityId",
                table: "SupportingServiceProvider",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportingServiceProvider_SpecializationId",
                table: "SupportingServiceProvider",
                column: "SpecializationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupportingServiceProvider");
        }
    }
}
