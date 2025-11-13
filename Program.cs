using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SzpitalnaKadra.Data;
using SzpitalnaKadra.Helpers;
using Microsoft.AspNetCore.Identity;
using SzpitalnaKadra.Models;

var builder = WebApplication.CreateBuilder(args);

// Dodaj CORS � nazwa polityki to "AllowFrontend"
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

// Dodaj hashowanie MD5 dla DbUser
builder.Services.AddScoped<IPasswordHasher<DbUser>, MD5PasswordHasher<DbUser>>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Szpitalna Kadra API V1");
        c.RoutePrefix = "swagger";
    });
}

// U�yj CORS przed autoryzacj�
app.UseCors("AllowFrontend");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Urls.Add("http://0.0.0.0:49537");
app.Run();