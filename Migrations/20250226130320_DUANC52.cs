using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_DUAN_C5.Migrations
{
    /// <inheritdoc />
    public partial class DUANC52 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityImageCard",
                table: "UserInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Diners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TaxCode",
                table: "Diners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityImageCard",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Diners");

            migrationBuilder.DropColumn(
                name: "TaxCode",
                table: "Diners");
        }
    }
}
