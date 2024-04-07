using Eat_Good_Data;
using Eat_Good_Data.Repositories.Generic.Implementation;
using Eat_Good_Data.Repositories.Generic.Interface;
using Eat_Good_Data.Seeding;
using Eat_Good_Services;
using Eat_Good_Services.Interfaces.Services;
using Eat_Good_Services.Services;
using EatGood_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
//var config = builder.Configuration;

var configuration = builder.Configuration;
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();


builder.Services.AddScoped<IAuthenticationServices, AuthenticationServices>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Registration of Db
builder.Services.AddDbContext<EatGood_DBContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("DefaultConnections")));

builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<EatGood_DBContext>()
                .AddDefaultTokenProviders();
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDataDependencies(builder.Configuration);


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
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    await Seeder.SeedRolesAndSuperAdmin(serviceProvider);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
