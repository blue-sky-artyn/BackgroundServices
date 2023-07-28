//using KlickbookEcommerceService.Data;
using KlickbookEcommerceService.Common.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MongoDB.Driver;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
//using MySql.Data.MySqlClient;

//using ModuleCoreService = KlickbookEcommerceService.API.Data.DataContextService;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

using AutoMapper;
using KlickbookEcommerceService.API;
using KlickbookEcommerceService.API._helper;
using KlickbookEcommerceService.Service;








using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson.Serialization.Conventions;
using System;
using KlickbookEcommerceService.API.Services;

var builder = WebApplication.CreateBuilder(args);
HostApplicationBuilder Appbuilder = Host.CreateApplicationBuilder(args);

var services = builder.Services;
var env = builder.Environment;
var configuration = builder.Configuration;




services.Configure<ConfigurationViewModel>(configuration.GetSection("configuration"));



builder.Services.AddControllers();

// Set IgnoreExtraElements to true
var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
ConventionRegistry.Register("IgnoreExtraElements", conventionPack, type => true);

#region MySQL 

//services.AddDbContextPool<MilanoBusinessContextService>(
//options => options = MySQLDbContextOptionsExtensions.UseMySQL(new DbContextOptionsBuilder<MilanoBusinessContextService>(), mySqlConnectionStr));

//services.AddTransient(_ => new DataContextService(options.Options));

//var serverVersion1 = new MySqlServerVersion(new Version(8, 0, 31));
string mySqlConnectionStr = configuration.GetSection("Connection:DataModel").Value;
var serverVersion = ServerVersion.AutoDetect(mySqlConnectionStr);
services.AddDbContext<MilanoBusinessContextService>(
            dbContextOptions => dbContextOptions
                .UseMySql(mySqlConnectionStr, serverVersion)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );

//services.AddDbContext<DataContextService>(options => options.UseMySql(mySqlConnectionStr, serverVersion));


//services.AddDbContextPool<MilanoBusinessContextService>(options => options.UseMySQL(mySqlConnectionStr));

//services.AddControllers().AddNewtonsoftJson(options =>
//{
//    options.UseMemberCasing();
//});

//builder.Services.AddDbContext<MilanoBusinessContextService>(dbContextOptions => dbContextOptions
//        .UseMySql(builder.Configuration["Connection:DataModel"], ServerVersion.AutoDetect(builder.Configuration["Connection:DataModel"]))
//        );



//services.AddDbContextPool<MilanoBusinessContextService>(
//    options => options.UseMySql(mySqlConnectionStr, serverVersion)
//);

//services.AddDbContextPool<MilanoBusinessContextService>(options => options.UseMySQL(mySqlConnectionStr));
//services.AddDbContext<MilanoBusinessContextService>(options => options.UseMySQL(mySqlConnectionStr));

//services.AddSingleton<MilanoBusinessContextService>(options => new options.UseMySql(mySqlConnectionStr, serverVersion));
//services.AddDbContext<MilanoBusinessContextService>(options => options.UseMySQL(mySqlConnectionStr));




//services.AddDbContextPool<MilanoBusinessContextService>(options => options.UseMySQL(mySqlConnectionStr));
string xcardmySqlConnectionStr = configuration.GetSection("Connection:DataModelxacrd").Value;
var serverVersionexcard = ServerVersion.AutoDetect(xcardmySqlConnectionStr);
services.AddDbContext<XcardDataContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(xcardmySqlConnectionStr, serverVersionexcard)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );








string xcardlivemySqlConnectionStr = configuration.GetSection("Connection:DataModelxacrdlive").Value;
var serverVersionexcardlive = ServerVersion.AutoDetect(xcardlivemySqlConnectionStr);
services.AddDbContext<XcardLiveDataContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(xcardlivemySqlConnectionStr, serverVersionexcardlive)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );

#endregion

#region AutoMapper
//services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//// Auto Mapper Configurations
////https://stackoverflow.com/questions/54239669/asp-net-core-2-2-unable-to-resolve-service-for-type-automapper-imapper
//var mappingConfig = new MapperConfiguration(mc =>
//{
//    mc.AddProfile(new AutoMapperProfile());
//});

//IMapper mapper = mappingConfig.CreateMapper();
//services.AddSingleton(mapper);
#endregion

#region Add DI
services.AddSingleton<IMongoClient>(s => new MongoClient(configuration.GetSection("mongoconnection:url").Value));

services.AddTransient<IProductService, ProductService>();
services.AddTransient<IXcartService, XcartService>();
services.AddTransient<IFtrMasterDataService, FtrMasterDataService>();
services.AddTransient<IMasterDataService, MasterDataService>();
services.AddTransient<ITenantService, TenantService>();
#endregion

#region Add Worker


services.AddHostedService<QueuedHostedService>();
//services.AddSingleton<IBackgroundTaskQueue, QueService>();





//IHostBackgroundService
services.AddHostedService<IHostQueManager>();



builder.Services.AddSingleton<MonitorLoop>();

//BackgroundService
builder.Services.AddHostedService<SMSQueManager>();
builder.Services.AddSingleton<IBackgroundTaskQueue>(_ =>
{
    if (!int.TryParse(builder.Configuration["QueueCapacity"], out var queueCapacity))
    {
        queueCapacity = 100;
    }

    return new QueService(queueCapacity);
});

IHost host = builder.Build();

MonitorLoop monitorLoop = host.Services.GetRequiredService<MonitorLoop>()!;
monitorLoop.StartMonitorLoop();

host.Run();

#endregion





builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //
    app.UseDeveloperExceptionPage();
}
#region Middlewares
//app.UseMiddleware<ErrorHandlerMiddleware>();
#endregion


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
