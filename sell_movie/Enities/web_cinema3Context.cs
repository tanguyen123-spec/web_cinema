using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using sell_movie.Models;

namespace sell_movie.Enities
{
    public partial class web_cinema3Context : DbContext
    {
        public web_cinema3Context()
        {
        }

        public web_cinema3Context(DbContextOptions<web_cinema3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Ctdatve> Ctdatves { get; set; } = null!;
        public virtual DbSet<CtdatveModels> CtdatveModels { get; set; } = null!;

        public virtual DbSet<Ghe> Ghes { get; set; } = null!;
        public virtual DbSet<GheModels> GheModels { get; set; } = null!;


        public virtual DbSet<Giave> Giaves { get; set; } = null!;
        public virtual DbSet<GiaveModels> GiaveModels { get; set; } = null!;

        public virtual DbSet<Khachhang> Khachhangs { get; set; } = null!;
        public virtual DbSet<KhachhangModels> KhachhangModels { get; set; } = null!;

        public virtual DbSet<Lichchieu> Lichchieus { get; set; } = null!;
        public virtual DbSet<LichchieuModels> LichChieuModels { get; set; } = null!;

        public virtual DbSet<Lichchieuphim> Lichchieuphims { get; set; } = null!;
        public virtual DbSet<LichchieuphimModels> LichchieuphimModels { get; set; } = null!;

        public virtual DbSet<Nguoidung> Nguoidungs { get; set; } = null!;
        public virtual DbSet<NguoidungModels> NguoidungModels { get; set; } = null!;

        public virtual DbSet<Nhanvien> Nhanviens { get; set; } = null!;
        public virtual DbSet<NhanvienModels> NhanvienModels { get; set; } = null!;

        public virtual DbSet<Phim> Phims { get; set; } = null!;
        public virtual DbSet<PhimModels> PhimModels { get; set; } = null!;

        public virtual DbSet<Phong> Phongs { get; set; } = null!;
        public virtual DbSet<PhongModels> PhongModels { get; set; } = null!;

        public virtual DbSet<Quocgium> Quocgia { get; set; } = null!;
        public virtual DbSet<QuocGiaModels> QuocGiaModels { get; set; } = null!;

        public virtual DbSet<Tdkhachhang> Tdkhachhangs { get; set; } = null!;
        public virtual DbSet<TdKhachHangModels> TdKhachHangModels { get; set; } = null!;

        public virtual DbSet<Thanhtoan> Thanhtoans { get; set; } = null!;
        public virtual DbSet<ThanhToanModels> ThanhToanModels { get; set; } = null!;

        public virtual DbSet<Theloai> Theloais { get; set; } = null!;
        public virtual DbSet<TheloaiModels> TheloaiModels { get; set; } = null!;

        public virtual DbSet<Trangthaighe> Trangthaighes { get; set; } = null!;
        public virtual DbSet<TrangThaiGheModels> TrangThaiGheModels { get; set; } = null!;

        public virtual DbSet<Ttdatve> Ttdatves { get; set; } = null!;
        public virtual DbSet<TtdatveModels> TtdatveModels { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(" Data Source=DESKTOP-9DIIF9V;Initial Catalog=web_cinema3;Integrated Security=True ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CtdatveModels>()
               .HasNoKey()
               .ToView(null); // Tên view hoặc null nếu không liên kết với view

            modelBuilder.Entity<GheModels>()
                .HasKey(e => e.MaGhe);
            modelBuilder.Entity<GiaveModels>()
           .HasKey(e => e.MaGiaVe);
            modelBuilder.Entity<KhachhangModels>()
                .HasKey(e => e.Makhachhang);
            modelBuilder.Entity<LichchieuModels>()
                 .HasKey(e => e.MaLichChieu);
            modelBuilder.Entity<LichchieuphimModels>()
                .HasKey(e => e.MaLichPhim);
            modelBuilder.Entity<NguoidungModels>()
                .HasKey(e => e.Username);
            modelBuilder.Entity<NhanvienModels>()
                .HasKey(e => e.MaNhanVien);
            modelBuilder.Entity<PhimModels>()
                .HasKey(e => e.MaPhim);
            modelBuilder.Entity<PhongModels>()
                .HasKey(e => e.MaPhong);
            modelBuilder.Entity<QuocGiaModels>()
                .HasKey(e => e.MaQuocgia);
            modelBuilder.Entity<TdKhachHangModels>()
                .HasNoKey();
            modelBuilder.Entity<ThanhToanModels>()
                .HasNoKey();
            modelBuilder.Entity<TheloaiModels>()
               .HasKey(e => e.MaTl);
            modelBuilder.Entity<TrangThaiGheModels>()
               .HasNoKey();
            modelBuilder.Entity<TtdatveModels>()
               .HasKey(e => e.MaDatVe);

            modelBuilder.Entity<Ctdatve>(entity =>
            {
                entity.HasKey(e => e.MaDatVe)
                    .HasName("PK__ctdatve__6A32C5934C602E04");

                entity.ToTable("ctdatve");

                entity.Property(e => e.MaDatVe).ValueGeneratedNever();

                entity.Property(e => e.MaGhe)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaGheNavigation)
                    .WithMany(p => p.Ctdatves)
                    .HasForeignKey(d => d.MaGhe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ctdatve__MaGhe__45F365D3");
            });

            modelBuilder.Entity<Ghe>(entity =>
            {
                entity.HasKey(e => e.MaGhe)
                    .HasName("PK__ghe__2D87404C255CAB94");

                entity.ToTable("ghe");

                entity.Property(e => e.MaGhe)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("maGhe");

                entity.Property(e => e.MaPhong)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TenGhe).HasMaxLength(255);

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.Ghes)
                    .HasForeignKey(d => d.MaPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ghe__MaPhong__4316F928");
            });

            modelBuilder.Entity<Giave>(entity =>
            {
                entity.HasKey(e => e.MaGiaVe)
                    .HasName("PK__giave__5A25399AD810550A");

                entity.ToTable("giave");

                entity.Property(e => e.MaGiaVe)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GiaVe1).HasColumnName("GiaVe");

                entity.Property(e => e.TenLoaiVe).HasMaxLength(255);
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makhachhang)
                    .HasName("PK__khachhan__52F5E83891D279B4");

                entity.ToTable("khachhang");

                entity.Property(e => e.Makhachhang)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("makhachhang");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(100)
                    .HasColumnName("diachi");

                entity.Property(e => e.Gioitinh).HasColumnName("gioitinh");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("sdt");

                entity.Property(e => e.Tenkhachhang)
                    .HasMaxLength(50)
                    .HasColumnName("tenkhachhang");
            });

            modelBuilder.Entity<Lichchieu>(entity =>
            {
                entity.HasKey(e => e.MaLichChieu)
                    .HasName("PK__lichchie__DC74019795E12A9C");

                entity.ToTable("lichchieu");

                entity.Property(e => e.MaLichChieu)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NgayChieu).HasColumnType("date");
            });

            modelBuilder.Entity<Lichchieuphim>(entity =>
            {
                entity.HasKey(e => e.MaLichPhim)
                    .HasName("PK__lichchie__775BC2F596459202");

                entity.ToTable("lichchieuphim");

                entity.Property(e => e.MaLichPhim)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaLichChieu)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaPhim)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaPhong)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaLichChieuNavigation)
                    .WithMany(p => p.Lichchieuphims)
                    .HasForeignKey(d => d.MaLichChieu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__lichchieu__MaLic__5070F446");

                entity.HasOne(d => d.MaPhimNavigation)
                    .WithMany(p => p.Lichchieuphims)
                    .HasForeignKey(d => d.MaPhim)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__lichchieu__MaPhi__52593CB8");

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.Lichchieuphims)
                    .HasForeignKey(d => d.MaPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__lichchieu__MaPho__5165187F");
            });

            modelBuilder.Entity<Nguoidung>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__nguoidun__F3DBC573DCD600A2");

                entity.ToTable("nguoidung");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.Nguoidungs)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__nguoidung__MaNha__5535A963");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__nhanvien__77B2CA479043B972");

                entity.ToTable("nhanvien");

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.Gioitinh).HasColumnName("gioitinh");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TenNhanVien).HasMaxLength(255);
            });

            modelBuilder.Entity<Phim>(entity =>
            {
                entity.HasKey(e => e.MaPhim)
                    .HasName("PK__phim__4AC03DE33606A42E");

                entity.ToTable("phim");

                entity.Property(e => e.MaPhim)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Anh)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Banner)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("banner");

                entity.Property(e => e.MaQuocGia)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaTl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MaTL");

                entity.Property(e => e.Mota).HasColumnType("text");

                entity.Property(e => e.Ngaykhoichieu)
                    .HasColumnType("date")
                    .HasColumnName("ngaykhoichieu");

                entity.Property(e => e.TenPhim).HasMaxLength(255);

                entity.Property(e => e.Thoiluong).HasColumnName("thoiluong");

                entity.Property(e => e.Trailer)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaQuocGiaNavigation)
                    .WithMany(p => p.Phims)
                    .HasForeignKey(d => d.MaQuocGia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__phim__MaQuocGia__3E52440B");

                entity.HasOne(d => d.MaTlNavigation)
                    .WithMany(p => p.Phims)
                    .HasForeignKey(d => d.MaTl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__phim__MaTL__3D5E1FD2");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.MaPhong)
                    .HasName("PK__phong__20BD5E5B53BA99DF");

                entity.ToTable("phong");

                entity.Property(e => e.MaPhong)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Socot).HasColumnName("socot");

                entity.Property(e => e.TenPhong).HasMaxLength(255);
            });

            modelBuilder.Entity<Quocgium>(entity =>
            {
                entity.HasKey(e => e.MaQuocgia)
                    .HasName("PK__quocgia__2B98FAF9CDA18054");

                entity.ToTable("quocgia");

                entity.Property(e => e.MaQuocgia)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TenQuocGia).HasMaxLength(255);
            });

            modelBuilder.Entity<Tdkhachhang>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tdkhachhang");

                entity.Property(e => e.HangKh)
                    .HasMaxLength(255)
                    .HasColumnName("HangKH");

                entity.Property(e => e.Makhachhang)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("makhachhang");

                entity.HasOne(d => d.MakhachhangNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Makhachhang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tdkhachha__makha__4BAC3F29");
            });

            modelBuilder.Entity<Thanhtoan>(entity =>
            {
                entity.HasKey(e => e.MaThanhToan)
                    .HasName("PK__thanhtoa__D4B2584483030543");

                entity.ToTable("thanhtoan");

                entity.Property(e => e.MaThanhToan)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NgayThanhToan).HasColumnType("date");

                entity.Property(e => e.Phuongthucthanhtoan)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phuongthucthanhtoan");

                entity.HasOne(d => d.MaDatVeNavigation)
                    .WithMany(p => p.Thanhtoans)
                    .HasForeignKey(d => d.MaDatVe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__thanhtoan__MaDat__5812160E");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.Thanhtoans)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__thanhtoan__MaNha__59063A47");
            });

            modelBuilder.Entity<Theloai>(entity =>
            {
                entity.HasKey(e => e.MaTl)
                    .HasName("PK__theloai__2725007175478BBD");

                entity.ToTable("theloai");

                entity.Property(e => e.MaTl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MaTL");

                entity.Property(e => e.TenTl)
                    .HasMaxLength(255)
                    .HasColumnName("TenTL");
            });

            modelBuilder.Entity<Trangthaighe>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("trangthaighe");

                entity.Property(e => e.MaLichChieu)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaPhong)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Maghe)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaLichChieuNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaLichChieu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__trangthai__MaLic__5CD6CB2B");

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__trangthai__MaPho__5BE2A6F2");

                entity.HasOne(d => d.MagheNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Maghe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__trangthai__Maghe__5AEE82B9");
            });

            modelBuilder.Entity<Ttdatve>(entity =>
            {
                entity.HasKey(e => e.MaDatVe)
                    .HasName("PK__ttdatve__6A32C59312234ECA");

                entity.ToTable("ttdatve");

                entity.Property(e => e.MaDatVe).ValueGeneratedNever();

                entity.Property(e => e.MaLichPhim)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NgayDat).HasColumnType("date");

                entity.HasOne(d => d.MaLichPhimNavigation)
                    .WithMany(p => p.Ttdatves)
                    .HasForeignKey(d => d.MaLichPhim)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ttdatve__MaLichP__5FB337D6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
