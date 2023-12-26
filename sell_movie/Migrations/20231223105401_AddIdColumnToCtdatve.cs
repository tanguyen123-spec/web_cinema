using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sell_movie.Migrations
{
    public partial class AddIdColumnToCtdatve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__thanhtoan__MaDat__6A30C649",
                table: "thanhtoan");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ctdatve__6A32C59385766494",
                table: "ctdatve");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ctdatve",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ctdatve",
                table: "ctdatve",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ctdatve_MaDatVe",
                table: "ctdatve",
                column: "MaDatVe");

            migrationBuilder.AddForeignKey(
                name: "FK__ctdatve__MaDatVe__5812160A",
                table: "ctdatve",
                column: "MaDatVe",
                principalTable: "ttdatve",
                principalColumn: "MaDatVe");

            migrationBuilder.AddForeignKey(
                name: "FK__thanhtoan__MaDat__6A30C649",
                table: "thanhtoan",
                column: "MaDatVe",
                principalTable: "ttdatve",
                principalColumn: "MaDatVe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ctdatve__MaDatVe__5812160A",
                table: "ctdatve");

            migrationBuilder.DropForeignKey(
                name: "FK__thanhtoan__MaDat__6A30C649",
                table: "thanhtoan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ctdatve",
                table: "ctdatve");

            migrationBuilder.DropIndex(
                name: "IX_ctdatve_MaDatVe",
                table: "ctdatve");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ctdatve");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ctdatve__6A32C59385766494",
                table: "ctdatve",
                column: "MaDatVe");

            migrationBuilder.AddForeignKey(
                name: "FK__thanhtoan__MaDat__6A30C649",
                table: "thanhtoan",
                column: "MaDatVe",
                principalTable: "ctdatve",
                principalColumn: "MaDatVe");
        }
    }
}
