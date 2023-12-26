using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sell_movie.Migrations
{
    public partial class addrefreshtoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "giave",
                columns: table => new
                {
                    MaGiaVe = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TenLoaiVe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GiaVe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__giave__5A25399ABC716995", x => x.MaGiaVe);
                });

            migrationBuilder.CreateTable(
                name: "khachhang",
                columns: table => new
                {
                    makhachhang = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    tenkhachhang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    diachi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gioitinh = table.Column<bool>(type: "bit", nullable: false),
                    sdt = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__khachhan__52F5E8385A6956C6", x => x.makhachhang);
                });

            migrationBuilder.CreateTable(
                name: "lichchieu",
                columns: table => new
                {
                    MaLichChieu = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    NgayChieu = table.Column<DateTime>(type: "date", nullable: false),
                    GioChieu = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__lichchie__DC740197AC81BFE7", x => x.MaLichChieu);
                });

            migrationBuilder.CreateTable(
                name: "nhanvien",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TenNhanVien = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SoDienThoai = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    gioitinh = table.Column<byte>(type: "tinyint", nullable: false),
                    ngaysinh = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__nhanvien__77B2CA47CF222EDA", x => x.MaNhanVien);
                });

            migrationBuilder.CreateTable(
                name: "phong",
                columns: table => new
                {
                    MaPhong = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TenPhong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SoChoNgoi = table.Column<int>(type: "int", nullable: false),
                    SoHang = table.Column<int>(type: "int", nullable: false),
                    socot = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__phong__20BD5E5B9A5DDFEE", x => x.MaPhong);
                });

            migrationBuilder.CreateTable(
                name: "quocgia",
                columns: table => new
                {
                    MaQuocgia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TenQuocGia = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__quocgia__2B98FAF9CC4A5084", x => x.MaQuocgia);
                });

            migrationBuilder.CreateTable(
                name: "theloai",
                columns: table => new
                {
                    MaTL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TenTL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__theloai__272500710E2EA98D", x => x.MaTL);
                });

            migrationBuilder.CreateTable(
                name: "tdkhachhang",
                columns: table => new
                {
                    makhachhang = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Diemkhachhang = table.Column<int>(type: "int", nullable: true),
                    HangKH = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tdkhachhang", x => x.makhachhang);
                    table.ForeignKey(
                        name: "FK__tdkhachha__makha__5DCAEF64",
                        column: x => x.makhachhang,
                        principalTable: "khachhang",
                        principalColumn: "makhachhang");
                });

            migrationBuilder.CreateTable(
                name: "nguoidung",
                columns: table => new
                {
                    username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    role = table.Column<bool>(type: "bit", nullable: false),
                    MaNhanVien = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__nguoidun__F3DBC5731E6A02BE", x => x.username);
                    table.ForeignKey(
                        name: "FK__nguoidung__MaNha__6754599E",
                        column: x => x.MaNhanVien,
                        principalTable: "nhanvien",
                        principalColumn: "MaNhanVien");
                });

            migrationBuilder.CreateTable(
                name: "ghe",
                columns: table => new
                {
                    maGhe = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TenGhe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MaPhong = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ghe__2D87404C107725C4", x => x.maGhe);
                    table.ForeignKey(
                        name: "FK__ghe__MaPhong__5535A963",
                        column: x => x.MaPhong,
                        principalTable: "phong",
                        principalColumn: "MaPhong");
                });

            migrationBuilder.CreateTable(
                name: "phim",
                columns: table => new
                {
                    MaPhim = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TenPhim = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ngaykhoichieu = table.Column<DateTime>(type: "date", nullable: false),
                    Mota = table.Column<string>(type: "text", nullable: false),
                    Anh = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Trailer = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    MaTL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    MaQuocGia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    banner = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    thoiluong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__phim__4AC03DE30B09D95B", x => x.MaPhim);
                    table.ForeignKey(
                        name: "FK__phim__MaQuocGia__5070F446",
                        column: x => x.MaQuocGia,
                        principalTable: "quocgia",
                        principalColumn: "MaQuocgia");
                    table.ForeignKey(
                        name: "FK__phim__MaTL__4F7CD00D",
                        column: x => x.MaTL,
                        principalTable: "theloai",
                        principalColumn: "MaTL");
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nguoidungUsername = table.Column<string>(type: "varchar(50)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_nguoidung_nguoidungUsername",
                        column: x => x.nguoidungUsername,
                        principalTable: "nguoidung",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ctdatve",
                columns: table => new
                {
                    MaDatVe = table.Column<int>(type: "int", nullable: false),
                    MaGhe = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    GiaVe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ctdatve__6A32C59385766494", x => x.MaDatVe);
                    table.ForeignKey(
                        name: "FK__ctdatve__MaGhe__5812160E",
                        column: x => x.MaGhe,
                        principalTable: "ghe",
                        principalColumn: "maGhe");
                });

            migrationBuilder.CreateTable(
                name: "trangthaighe",
                columns: table => new
                {
                    Maghe = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TrangThai = table.Column<byte>(type: "tinyint", nullable: false),
                    MaPhong = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    MaLichChieu = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trangthaighe", x => x.Maghe);
                    table.ForeignKey(
                        name: "FK__trangthai__Maghe__6D0D32F4",
                        column: x => x.Maghe,
                        principalTable: "ghe",
                        principalColumn: "maGhe");
                    table.ForeignKey(
                        name: "FK__trangthai__MaLic__6EF57B66",
                        column: x => x.MaLichChieu,
                        principalTable: "lichchieu",
                        principalColumn: "MaLichChieu");
                    table.ForeignKey(
                        name: "FK__trangthai__MaPho__6E01572D",
                        column: x => x.MaPhong,
                        principalTable: "phong",
                        principalColumn: "MaPhong");
                });

            migrationBuilder.CreateTable(
                name: "lichchieuphim",
                columns: table => new
                {
                    MaLichPhim = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    MaLichChieu = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    MaPhong = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    MaPhim = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__lichchie__775BC2F5F00D7847", x => x.MaLichPhim);
                    table.ForeignKey(
                        name: "FK__lichchieu__MaLic__628FA481",
                        column: x => x.MaLichChieu,
                        principalTable: "lichchieu",
                        principalColumn: "MaLichChieu");
                    table.ForeignKey(
                        name: "FK__lichchieu__MaPhi__6477ECF3",
                        column: x => x.MaPhim,
                        principalTable: "phim",
                        principalColumn: "MaPhim");
                    table.ForeignKey(
                        name: "FK__lichchieu__MaPho__6383C8BA",
                        column: x => x.MaPhong,
                        principalTable: "phong",
                        principalColumn: "MaPhong");
                });

            migrationBuilder.CreateTable(
                name: "thanhtoan",
                columns: table => new
                {
                    MaThanhToan = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    MaDatVe = table.Column<int>(type: "int", nullable: false),
                    MaNhanVien = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "date", nullable: false),
                    phuongthucthanhtoan = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TongTienThanhToan = table.Column<decimal>(type: "int(18, 2)", nullable: false)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__thanhtoa__D4B2584496E304E5", x => x.MaThanhToan);
                    table.ForeignKey(
                        name: "FK__thanhtoan__MaDat__6A30C649",
                        column: x => x.MaDatVe,
                        principalTable: "ctdatve",
                        principalColumn: "MaDatVe");
                    table.ForeignKey(
                        name: "FK__thanhtoan__MaNha__6B24EA82",
                        column: x => x.MaNhanVien,
                        principalTable: "nhanvien",
                        principalColumn: "MaNhanVien");
                });

            migrationBuilder.CreateTable(
                name: "ttdatve",
                columns: table => new
                {
                    MaDatVe = table.Column<int>(type: "int", nullable: false),
                    MaLichPhim = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    NgayDat = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ttdatve__6A32C59304FC1FD9", x => x.MaDatVe);
                    table.ForeignKey(
                        name: "FK__ttdatve__MaLichP__71D1E811",
                        column: x => x.MaLichPhim,
                        principalTable: "lichchieuphim",
                        principalColumn: "MaLichPhim");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ctdatve_MaGhe",
                table: "ctdatve",
                column: "MaGhe");

            migrationBuilder.CreateIndex(
                name: "IX_ghe_MaPhong",
                table: "ghe",
                column: "MaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_lichchieuphim_MaLichChieu",
                table: "lichchieuphim",
                column: "MaLichChieu");

            migrationBuilder.CreateIndex(
                name: "IX_lichchieuphim_MaPhim",
                table: "lichchieuphim",
                column: "MaPhim");

            migrationBuilder.CreateIndex(
                name: "IX_lichchieuphim_MaPhong",
                table: "lichchieuphim",
                column: "MaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_nguoidung_MaNhanVien",
                table: "nguoidung",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_phim_MaQuocGia",
                table: "phim",
                column: "MaQuocGia");

            migrationBuilder.CreateIndex(
                name: "IX_phim_MaTL",
                table: "phim",
                column: "MaTL");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_nguoidungUsername",
                table: "RefreshTokens",
                column: "nguoidungUsername");

            migrationBuilder.CreateIndex(
                name: "IX_thanhtoan_MaDatVe",
                table: "thanhtoan",
                column: "MaDatVe");

            migrationBuilder.CreateIndex(
                name: "IX_thanhtoan_MaNhanVien",
                table: "thanhtoan",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_trangthaighe_MaLichChieu",
                table: "trangthaighe",
                column: "MaLichChieu");

            migrationBuilder.CreateIndex(
                name: "IX_trangthaighe_MaPhong",
                table: "trangthaighe",
                column: "MaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_ttdatve_MaLichPhim",
                table: "ttdatve",
                column: "MaLichPhim");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "giave");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "tdkhachhang");

            migrationBuilder.DropTable(
                name: "thanhtoan");

            migrationBuilder.DropTable(
                name: "trangthaighe");

            migrationBuilder.DropTable(
                name: "ttdatve");

            migrationBuilder.DropTable(
                name: "nguoidung");

            migrationBuilder.DropTable(
                name: "khachhang");

            migrationBuilder.DropTable(
                name: "ctdatve");

            migrationBuilder.DropTable(
                name: "lichchieuphim");

            migrationBuilder.DropTable(
                name: "nhanvien");

            migrationBuilder.DropTable(
                name: "ghe");

            migrationBuilder.DropTable(
                name: "lichchieu");

            migrationBuilder.DropTable(
                name: "phim");

            migrationBuilder.DropTable(
                name: "phong");

            migrationBuilder.DropTable(
                name: "quocgia");

            migrationBuilder.DropTable(
                name: "theloai");
        }
    }
}
