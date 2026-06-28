using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WMS.Application.Profiles;
using WMS.Application.Services;
using WMS.Application.Validators;
using WMS.Domain.Interfaces;
using WMS.Infrastructure.Data;
using WMS.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ========== 数据库配置 ==========
// 注册 SQLite 数据库上下文
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// ========== 仓储和工作单元 ==========
// 注册工作单元（Scoped 生命周期，每个请求一个实例）
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// ========== AutoMapper 配置 ==========
// 注册映射配置
builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);

// ========== FluentValidation 配置 ==========
// 注册所有校验器
builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

// ========== 业务服务注册 ==========
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProductService, ProductService>();

// ========== JWT 认证配置 ==========
var jwtKey = builder.Configuration["Jwt:Key"] ?? "your-super-long-secret-key-over-32-chars-here";
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? "wms-api";
var jwtAudience = builder.Configuration["Jwt:Audience"] ?? "wms-client";

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
        ClockSkew = TimeSpan.Zero // 严格校验过期时间，不预留容差
    };
});

builder.Services.AddAuthorization();

// ========== 控制器与 Swagger ==========
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ========== 中间件管道 ==========
// 开发环境启用 Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 认证和授权中间件（顺序不可颠倒）
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// 根路径重定向到 Swagger 页面
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
