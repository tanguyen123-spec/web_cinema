using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using sell_movie.Models;

namespace sell_movie.Entities
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
        public virtual DbSet<Ghe> Ghes { get; set; } = null!;
        public virtual DbSet<Giave> Giaves { get; set; } = null!;
        public virtual DbSet<Khachhang> Khachhangs { get; set; } = null!;
        public virtual DbSet<Lichchieu> Lichchieus { get; set; } = null!;
        public virtual DbSet<Lichchieuphim> Lichchieuphims { get; set; } = null!;
        public virtual DbSet<Nguoidung> Nguoidungs { get; set; } = null!;
        public virtual DbSet<Nhanvien> Nhanviens { get; set; } = null!;
        public virtual DbSet<Phim> Phims { get; set; } = null!;
        public virtual DbSet<Phong> Phongs { get; set; } = null!;
        public virtual DbSet<Quocgium> Quocgia { get; set; } = null!;
        public virtual DbSet<Tdkhachhang> Tdkhachhangs { get; set; } = null!;

        public virtual DbSet<Thanhtoan> Thanhtoans { get; set; } = null!;
        public virtual DbSet<Theloai> Theloais { get; set; } = null!;
        public virtual DbSet<Trangthaighe> Trangthaighes { get; set; } = null!;
        public virtual DbSet<Ttdatve> Ttdatves { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(" Data Source=DESKTOP-9DIIF9V;Initial Catalog=web_cinema3;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Ctdatve>(entity =>
            {
                entity.HasKey(e => e.MaDatVe)
                    .HasName("PK__ctdatve__6A32C59385766494");

                entity.ToTable("ctdatve");

                entity.Property(e => e.MaDatVe).ValueGeneratedNever();

                entity.Property(e => e.MaGhe)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaGheNavigation)
                    .WithMany(p => p.Ctdatves)
                    .HasForeignKey(d => d.MaGhe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ctdatve__MaGhe__5812160E");
            });

            modelBuilder.Entity<Ghe>(entity =>
            {
                entity.HasKey(e => e.MaGhe)
                    .HasName("PK__ghe__2D87404C107725C4");

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
                    .HasConstraintName("FK__ghe__MaPhong__5535A963");
            });

            modelBuilder.Entity<Giave>(entity =>
            {
                entity.HasKey(e => e.MaGiaVe)
                    .HasName("PK__giave__5A25399ABC716995");

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
                    .HasName("PK__khachhan__52F5E8385A6956C6");

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
                    .HasName("PK__lichchie__DC740197AC81BFE7");

                entity.ToTable("lichchieu");

                entity.Property(e => e.MaLichChieu)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NgayChieu).HasColumnType("date");
            });

            modelBuilder.Entity<Lichchieuphim>(entity =>
            {
                entity.HasKey(e => e.MaLichPhim)
                    .HasName("PK__lichchie__775BC2F5F00D7847");

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
                    .HasConstraintName("FK__lichchieu__MaLic__628FA481");

                entity.HasOne(d => d.MaPhimNavigation)
                    .WithMany(p => p.Lichchieuphims)
                    .HasForeignKey(d => d.MaPhim)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__lichchieu__MaPhi__6477ECF3");

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.Lichchieuphims)
                    .HasForeignKey(d => d.MaPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__lichchieu__MaPho__6383C8BA");
            });

            modelBuilder.Entity<Nguoidung>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__nguoidun__F3DBC5731E6A02BE");

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
                    .HasConstraintName("FK__nguoidung__MaNha__6754599E");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__nhanvien__77B2CA47CF222EDA");

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
                    .HasName("PK__phim__4AC03DE30B09D95B");

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
                    .HasConstraintName("FK__phim__MaQuocGia__5070F446");

                entity.HasOne(d => d.MaTlNavigation)
                    .WithMany(p => p.Phims)
                    .HasForeignKey(d => d.MaTl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__phim__MaTL__4F7CD00D");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.MaPhong)
                    .HasName("PK__phong__20BD5E5B9A5DDFEE");

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
                    .HasName("PK__quocgia__2B98FAF9CC4A5084");

                entity.ToTable("quocgia");

                entity.Property(e => e.MaQuocgia)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TenQuocGia).HasMaxLength(255);
            });

            modelBuilder.Entity<Tdkhachhang>(entity =>
            {
                entity.HasKey(e => e.Makhachhang);

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
                    .HasConstraintName("FK__tdkhachha__makha__5DCAEF64");
            });

            modelBuilder.Entity<Thanhtoan>(entity =>
            {
                entity.HasKey(e => e.MaThanhToan)
                    .HasName("PK__thanhtoa__D4B2584496E304E5");

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
                    .HasConstraintName("FK__thanhtoan__MaDat__6A30C649");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.Thanhtoans)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__thanhtoan__MaNha__6B24EA82");
            });

            modelBuilder.Entity<Theloai>(entity =>
            {
                entity.HasKey(e => e.MaTl)
                    .HasName("PK__theloai__272500710E2EA98D");

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
                entity.HasKey(e => e.Maghe);

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
                    .HasConstraintName("FK__trangthai__MaLic__6EF57B66");

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__trangthai__MaPho__6E01572D");

                entity.HasOne(d => d.MagheNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Maghe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__trangthai__Maghe__6D0D32F4");
            });

            modelBuilder.Entity<Ttdatve>(entity =>
            {
                entity.HasKey(e => e.MaDatVe)
                    .HasName("PK__ttdatve__6A32C59304FC1FD9");

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
                    .HasConstraintName("FK__ttdatve__MaLichP__71D1E811");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
