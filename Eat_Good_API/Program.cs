using Eat_Good_Data;
using Eat_Good_Services;
using Microsoft.AspNetCore.Identity;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

var configuration = builder.Configuration;
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDataDependencies(builder.Configuration);
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<EatGood_DBContext>()
    .AddDefaultTokenProviders();
builder.Services.AddServiceDependencies(builder.Configuration);
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
