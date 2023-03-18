using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abp.Albert.Bussiness.Migrations
{
    public partial class UpdateProductandProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_AppProduct_ProductId",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "ProductGuid",
                table: "ProductImage");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "ProductImage",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductImage",
                newName: "ImageStatus");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "AppProduct",
                newName: "ProductStock");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AppProduct",
                newName: "ProductUrl");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "ProductImage",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "ImageSort",
                table: "ProductImage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "AppProduct",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProductDescription",
                table: "AppProduct",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "ProductPrice",
                table: "AppProduct",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductSold",
                table: "AppProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductSort",
                table: "AppProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductStatus",
                table: "AppProduct",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProductTitle",
                table: "AppProduct",
                type: "varchar(64)",
                maxLength: 64,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "ProductVirtualprice",
                table: "AppProduct",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_AppProduct_ProductId",
                table: "ProductImage",
                column: "ProductId",
                principalTable: "AppProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_AppProduct_ProductId",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "ImageSort",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "AppProduct");

            migrationBuilder.DropColumn(
                name: "ProductDescription",
                table: "AppProduct");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "AppProduct");

            migrationBuilder.DropColumn(
                name: "ProductSold",
                table: "AppProduct");

            migrationBuilder.DropColumn(
                name: "ProductSort",
                table: "AppProduct");

            migrationBuilder.DropColumn(
                name: "ProductStatus",
                table: "AppProduct");

            migrationBuilder.DropColumn(
                name: "ProductTitle",
                table: "AppProduct");

            migrationBuilder.DropColumn(
                name: "ProductVirtualprice",
                table: "AppProduct");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "ProductImage",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "ImageStatus",
                table: "ProductImage",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductUrl",
                table: "AppProduct",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductStock",
                table: "AppProduct",
                newName: "Price");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "ProductImage",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductGuid",
                table: "ProductImage",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_AppProduct_ProductId",
                table: "ProductImage",
                column: "ProductId",
                principalTable: "AppProduct",
                principalColumn: "Id");
        }
    }
}
