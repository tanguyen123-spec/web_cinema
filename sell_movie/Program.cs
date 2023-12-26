using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using sell_movie.Entities;
using sell_movie.Repository;
using sell_movie.Services;
using AutoMapper;

using sell_movie.Models;
using sell_movie.Filters;
using Microsoft.Extensions.FileProviders;
using System.Text;
using sell_movie.Secure.Key;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using sell_movie.Secure.Service;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var optionsBuilder = new DbContextOptionsBuilder<web_cinema3Context>();

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
builder.Services.AddControllers(
//options =>
//{
//    options.Filters.Add(new MyFilterAtribute("Global"));
//    options.Filters.Add(new MyFilterResourceFilter("Global"));
//    options.Filters.AddService<MyFilterResultFilterAttribute>();

    //}
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<web_cinema3Context>();
//builder.Services.AddTransient<MyFilterResultFilterAttribute>();
builder.Services.AddScoped<IGheService, GheServices>();
builder.Services.AddScoped<IPhongService, PhongServices>();
builder.Services.AddScoped<ICtDatVeService, Ctdatveservice>();
builder.Services.AddScoped<ITdKhachHangService, TdKhachHangServices>();
builder.Services.AddScoped<ITheLoaiService, TheLoaiServices>();
builder.Services.AddScoped<ILichChieuPhimService, LichChieuPhimServices>();
builder.Services.AddScoped<ITtDatVeService, TtDatVeServices>();
builder.Services.AddScoped<ITrangThaiGheService, TrangThaiGheServices>();
builder.Services.AddScoped<IKhachHangService, KhachHangServices>();
builder.Services.AddScoped<INguoiDungService, NguoiDungServices>();
builder.Services.AddScoped<IGiaVeService, GiaVeServices>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(MyRepository<>));
builder.Services.AddScoped<ILichChieuService, LichChieuServices>();
builder.Services.AddScoped<IDisInforService, DisInforService>();
builder.Services.AddScoped<IPhimService, PhimServices>();
builder.Services.AddScoped<INhanVienService, NhanVienServices>();
builder.Services.AddScoped<IGetIDGheService, GetIdGheService>();
builder.Services.AddScoped<IQuocGiaService, QuocGiaServices>();
builder.Services.AddScoped<IThanhToanService,ThanhToanServices>();
builder.Services.AddScoped<ITokenServices,TokenServices>();
builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));
optionsBuilder.EnableSensitiveDataLogging();

//lấy giá trị secretkey
var secretKey = builder.Configuration["AppSettings:SecretKey"];
//chuyển đổi từ string sang mảng byte
//SymmetricSecurityKey, được sử dụng trong JWT,
//yêu cầu secret key ở dạng mảng byte.
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            //tự cấp token
            ValidateIssuer = false,
            ValidateAudience = false,
            //ký vào token
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
            ClockSkew = TimeSpan.Zero,
        };
        opt.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
                Console.WriteLine($"Đã Nhận token");
                return Task.CompletedTask;
            }
        };
        opt.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
                Console.WriteLine($"Đã Nhận token");
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddControllers();



builder.Services.AddScoped<IGetPhimByIdNgayChieuService, GetPhimByIDNgayChieuService>();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
 var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
