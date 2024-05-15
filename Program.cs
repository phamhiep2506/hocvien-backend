using Interfaces.IPayloads;
using Interfaces.IServices;
using Microsoft.EntityFrameworkCore;
using Models;
using Payloads;
using Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString(
    "DefaultConnection"
);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<ILoaiKhoaHocService, LoaiKhoaHocService>();
builder.Services.AddScoped<IKhoaHocService, KhoaHocService>();
builder.Services.AddScoped<IResponses, Responses>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();
