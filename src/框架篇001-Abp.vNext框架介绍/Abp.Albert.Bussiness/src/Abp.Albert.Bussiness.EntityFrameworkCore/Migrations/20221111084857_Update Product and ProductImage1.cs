using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abp.Albert.Bussiness.Migrations
{
    public partial class UpdateProductandProductImage1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_AppProduct_ProductId",
                table: "ProductImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppProduct",
                table: "AppProduct");

            migrationBuilder.RenameTable(
                name: "AppProduct",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_Products_ProductId",
                table: "ProductImage",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Products_ProductId",
                table: "ProductImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "AppProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppProduct",
                table: "AppProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_AppProduct_ProductId",
                table: "ProductImage",
                column: "ProductId",
                principalTable: "AppProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
