using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// extension methods from ServiceExtensions class
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

builder.Services.ConfigureLoggerService(); // ConfigureLoggerService() must be added before AddControllers()
builder.Services.ConfigureSqlContext(builder.Configuration); // ConfigureLoggerService() must be added before AddControllers()
builder.Services.ConfigureRepositoryWapper();
builder.Services.AddControllers();

//for logger service

LogManager.Setup().LoadConfigurationFromFile("/nlog.cofig");
//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config")); // this is old version coding.


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
}) ;

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
