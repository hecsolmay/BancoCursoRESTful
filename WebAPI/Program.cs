using Application;
using Identity;
using Identity.Models;
using Identity.Seeds;
using Microsoft.AspNetCore.Identity;
using Persistence;
using Shared;
using WebAPI.Extentions;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.


var hostBuilder = Host.CreateDefaultBuilder(args).Build();

using (var scope = hostBuilder.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await DefaultRoles.SeedAsync(userManager, roleManager);
        await DefaultAdminUser.SeedAsync(userManager, roleManager);
        await DefaultBasicUser.SeedAsync(userManager, roleManager);

    }
    catch (Exception)
    {

        throw;
    }
    hostBuilder.Run();
}






// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAplicationLayer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddIdentityInfraestruture(builder.Configuration);
builder.Services.AddPersistenceInfraestructure(builder.Configuration);
builder.Services.AddSharedInfraestruture(builder.Configuration);

builder.Services.AddApiVersioningExtension();
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

app.UseErrorHandlingMiddleware();

app.UseAuthentication();

app.MapControllers();

app.Run();
