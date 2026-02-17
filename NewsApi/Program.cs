using Microsoft.EntityFrameworkCore;
using NewsApi;
using NewsApi.DataAccess;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();

services.AddOpenApi();
services.AddSwaggerGen();

services.RegisterOptions(configuration);
services.RegisterServices();
services.RegisterMappers();


services.UseNpgsqlDbContext(configuration);
services.RegisterMessageBroker();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
