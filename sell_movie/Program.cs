using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using sell_movie.Entities;
using sell_movie.Repository;
using sell_movie.Services;
using AutoMapper;

using sell_movie.Models;
using sell_movie.Filters;

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
    options.Filters.Add(new MyFilterAtribute("Global"));
    options.Filters.Add(new MyFilterResourceFilter("Global"));
    options.Filters.AddService<MyFilterResultFilterAttribute>();


});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<web_cinema3Context>();
builder.Services.AddTransient<MyFilterResultFilterAttribute>();
builder.Services.AddScoped<GheServices>();
builder.Services.AddScoped<PhongServices>();
builder.Services.AddScoped<CtdatveService>();
builder.Services.AddScoped<TdKhachHangServices>();
builder.Services.AddScoped<TheLoaiServices>();
builder.Services.AddScoped<LichChieuPhimServices>();
builder.Services.AddScoped<TtDatVeServices>();
builder.Services.AddScoped<TrangThaiGheServices>();
builder.Services.AddScoped<KhachHangServices>();
builder.Services.AddScoped<NguoiDungServices>();
builder.Services.AddScoped<GiaVeServices>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(MyRepository<>));




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
