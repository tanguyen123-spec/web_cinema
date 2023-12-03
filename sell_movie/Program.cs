using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using sell_movie.Enities;
using sell_movie.Repository;
using sell_movie.Services;
using AutoMapper;

using sell_movie.Models;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:52107",
                                              "http://localhost:52107");
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();

                      });
});
// Add services to the container.

builder.Services.AddControllers();
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
builder.Services.AddScoped<IPhongServices, PhongServices>();
builder.Services.AddScoped<ILichchieuRepository,LichchieuRepository>();
builder.Services.AddScoped<ILichchieuService, LichchieuService>();
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
