using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using sell_movie.Enities;
using sell_movie.Repository;
using sell_movie.Services;
using AutoMapper;

using sell_movie.Models;
using Sell_movie_ticket.Repository;
using Sell_movie_ticket.Services;


var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                              "http://localhost:4200");
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();

                      });
});
// Add services to the container.
builder.Services.AddControllers(options =>
{
    
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<web_cinema3Context>();

//---------------------------------------------------
// Đăng ký IGiaVeRepository và GiaVeRepository
builder.Services.AddScoped<IGiaveRepository, GiaveRepository>();
builder.Services.AddAutoMapper(typeof(GiaveService));
// Đăng ký IGiaVeService và GiaVeService
builder.Services.AddScoped<IGiaveService, GiaveService>();
//-----------------------------------------------------------
// Đăng ký ICtdatveRepository và CtdatveRepository
builder.Services.AddScoped<IRepository<CtdatveModels>, CtdatveRepository>();
//// Đăng ký ICtdatveService và CtdatveService
builder.Services.AddScoped<ICtdatveService, CtdatveService>();
builder.Services.AddScoped<IRepository<TtdatveModels>, TtDatVeRepository>();
builder.Services.AddScoped<ITtDatVeServices,TtDatVeServices>();
builder.Services.AddScoped<IRepository<LichchieuphimModels>, LichChieuPhimRepository>();
builder.Services.AddScoped<ILichChieuPhimServices, LichChieuPhimServices>();
builder.Services.AddScoped<IRepository<PhongModels>, PhongRepository>();
builder.Services.AddScoped< PhongServices>();
builder.Services.AddScoped<IRepository<LichChieuModels>,LichChieuRepository>();
builder.Services.AddScoped<ILichChieuService, LichChieuService>();
builder.Services.AddScoped<IGheServices, GheService>();
builder.Services.AddScoped<IRepository<GheModels>, GheRepository>();

builder.Services.AddScoped< ITdKhachHangService,TdKhachHangService>();
builder.Services.AddScoped<MyRepository<Tdkhachhang>>();


builder.Services.AddScoped<MyRepository<TrangThaiGheModels>>();
builder.Services.AddScoped<IThanhtoanRepository, ThanhtoanRepository>();
builder.Services.AddScoped<IRepository<PhimModels>, PhimRepository>();
builder.Services.AddScoped<IRepository<NhanvienModels>, NhanvienRepository>();
//-----
builder.Services.AddScoped<IQuocGiaRepository, QuocGiaRepository>();
builder.Services.AddScoped<IQuocGiaService, QuocGiaService>();
builder.Services.AddScoped<IRepository<NguoidungModels>, NguoidungRepository>();
builder.Services.AddScoped<INguoidungService, NguoidungService>();
builder.Services.AddScoped<IQuocGiaService, QuocGiaService>();
builder.Services.AddAutoMapper(typeof(QuocGiaService));
builder.Services.AddScoped<IThanhtoanService, ThanhtoanService>();
builder.Services.AddScoped<IPhimService, PhimService>();
builder.Services.AddScoped<INhanvienService, NhanvienService>();




//---------------------------------------------------------
// Đăng ký repository
builder.Services.AddScoped<IKhachhangRepository, KhachhangRepository>();
// Đăng ký service
builder.Services.AddScoped<IKhachhangService, KhachhangService>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
