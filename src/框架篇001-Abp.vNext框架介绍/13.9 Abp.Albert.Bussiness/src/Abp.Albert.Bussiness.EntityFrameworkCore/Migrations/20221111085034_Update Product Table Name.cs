using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abp.Albert.Bussiness.Migrations
{
    public partial class UpdateProductTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Products_ProductId",
                table: "ProductImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "t_Product");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_Product",
                table: "t_Product",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_t_Product_ProductId",
                table: "ProductImage",
                column: "ProductId",
                principalTable: "t_Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_t_Product_ProductId",
                table: "ProductImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_Product",
                table: "t_Product");

            migrationBuilder.RenameTable(
                name: "t_Product",
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
    }
}
