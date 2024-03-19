using BankManagementApi.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BankManagementApi.Data;
using BankManagementApi.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDataContext>(options => 
{
    options.UseInMemoryDatabase("BankManagementSystem");
    options.EnableSensitiveDataLogging();
});

builder.Services.AddIdentity<NewUserDetails, IdentityRole>().AddEntityFrameworkStores<AppDataContext>().AddDefaultTokenProviders();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
