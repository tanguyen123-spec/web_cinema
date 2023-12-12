using CsvHelper;
using Microsoft.EntityFrameworkCore;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;
using System.Globalization;

namespace sell_movie.Services
{
    public class KhachHangServices : MyRepository<Khachhang>
    {
        private readonly web_cinema3Context _context;
        public KhachHangServices(web_cinema3Context context) : base(context)
        {
            _context = context;
        }
        public async Task AddByModels(KhachhangModels khachhang)
        {
            var kh = new Khachhang
            {
                Makhachhang = khachhang.Makhachhang,
                Tenkhachhang = khachhang.Tenkhachhang,
                Diachi = khachhang.Diachi,
                Gioitinh = khachhang.Gioitinh,
                Sdt = khachhang.Sdt,
            };
            var tdkh = new Tdkhachhang
            {
                Diemkhachhang = 0,
                Makhachhang = kh.Makhachhang,
                HangKh = "None",
            };

            // Thêm bản ghi vào bảng "khachhang" trước
            _context.Add(kh);
            await _context.SaveChangesAsync();

            // Thêm bản ghi vào bảng "tdkhachhang" sau
            _context.Add(tdkh);
            await _context.SaveChangesAsync();

            // Xóa các bản ghi liên quan trong bảng "tdkhachhang"
            var relatedTdkh = await _context.Tdkhachhangs
                .Where(t => t.Makhachhang == kh.Makhachhang)
                .ToListAsync();

            if (relatedTdkh.Count > 0)
            {
                _context.RemoveRange(relatedTdkh);
                await _context.SaveChangesAsync();
            }

            // Ghi dữ liệu của khách hàng vào tệp CSV
            using (var writer = new StreamWriter("./CSVhelper/KhachHang.csv", true))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                var customerData = new KhachhangModels
                {
                    Makhachhang = kh.Makhachhang,
                    Tenkhachhang = kh.Tenkhachhang,
                    Diachi = kh.Diachi,
                    Gioitinh = kh.Gioitinh,
                    Sdt = kh.Sdt
                };

                csv.WriteRecord(customerData);
                csv.NextRecord(); // Đặt xuống dòng mới cho mỗi thông tin khách hàng
                await writer.FlushAsync();
            }
        }
        public async Task Delete(string id)
        {
            var khachhang = await GetById(id);

            if (khachhang != null)
            {
                // Xóa các bản ghi liên quan trong bảng "tdkhachhang"
                var relatedTdkh = await _context.Tdkhachhangs
                    .Where(t => t.Makhachhang == id)
                    .ToListAsync();

                if (relatedTdkh.Count > 0)
                {
                    _context.RemoveRange(relatedTdkh);
                }

                // Xóa khách hàng
                _context.Remove(khachhang);
                await _context.SaveChangesAsync();

                // Xóa khách hàng trong tệp CSV
                var csvPath = "./CSVhelper/KhachHang.csv";
                var records = new List<KhachhangModels>(); // Danh sách tất cả các bản ghi trong tệp CSV

                // Đọc tất cả các bản ghi từ tệp CSV
                using (var reader = new StreamReader(csvPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    records = csv.GetRecords<KhachhangModels>().ToList();
                }

                // Loại bỏ bản ghi tương ứng trong danh sách
                var recordToDelete = records.FirstOrDefault(r => r.Makhachhang == id);
                if (recordToDelete != null)
                {
                    records.Remove(recordToDelete);

                    // Ghi lại dữ liệu đã chỉnh sửa vào tệp CSV
                    using (var writer = new StreamWriter(csvPath, false))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(records);
                        await writer.FlushAsync();
                    }
                }
            }
        }

    }
}