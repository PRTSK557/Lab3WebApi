using Microsoft.EntityFrameworkCore;
using PROKSRent_WebAPI.Data;
using ProksRent_WebAPI.Repositories;
using ProksRent_WebAPI.Services;
using ProksRent_WebAPI.Middleware;
using ProksRent_WebAPI.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Додати контролери
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Залежності для репозиторіїв та сервісів
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IBrandService, BrandService>();

builder.Services.AddScoped<ITransmissionTypeRepository, TransmissionTypeRepository>();
builder.Services.AddScoped<ITransmissionTypeService, TransmissionTypeService>();

builder.Services.AddScoped<IFuelTypeRepository, FuelTypeRepository>();
builder.Services.AddScoped<IFuelTypeService, FuelTypeService>();

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();

// Додати політику CORS (якщо фронт і бекенд працюють окремо)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp", policy =>
    {
        policy.WithOrigins("http://localhost:7157")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Конфігурація HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowBlazorApp");


app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
