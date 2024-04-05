using Eat_Good_API;
using Eat_Good_API.Configurations;
using Eat_Good_Data;
using Eat_Good_Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.AddServiceDependencies(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.ConfigureApplicationCookie(op => op.LoginPath = "/UserAuthentication/Login");

// Seed roles and super admin user
builder.Services.AddScoped<Seeder>(); // Register the Seeder class
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    Seeder.SeedRolesAndSuperAdmin(scope.ServiceProvider);
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
