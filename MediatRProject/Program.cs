using AutoMapper;
using MediatR;
using MediatRProject.ApiFolder.Handlers;
using MediatRProject.ApiFolder.Requests;
using MediatRProject.DatabaseProject;
using MediatRProject.Mappings;
using MediatRProject.Models;
using MediatRProject.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.NetworkInformation;
using System.Reflection;
using NLog.Web;
using Microsoft.AspNetCore.Hosting;
using NLog;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<SqlServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContactsApiConnectionString")));
    builder.Services.AddAutoMapper(typeof(MappingProfile));
    builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(InsertApiHandler).Assembly));
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
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
}
catch(Exception ex)
{
    logger.Error(ex); 
    throw(ex);
}
finally
{
    NLog.LogManager.Shutdown();
}