using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sell_movie.Migrations
{
    public partial class AddTongTienThanhToanColumnToThanhToan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TongTienThanhToan",
                table: "thanhtoan",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TongTienThanhToan",
                table: "thanhtoan");
        }
    }
}
