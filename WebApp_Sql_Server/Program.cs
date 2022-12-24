using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApp_Sql_Server;
using WebApp_Sql_Server.Data;
using WebApp_Sql_Server.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<AzureDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureDb")));
builder.Services.AddScoped(p =>
    p.GetRequiredService<IDbContextFactory<AzureDbContext>>()
        .CreateDbContext()
);

builder.Services.AddTransient<PersonService>();

builder.Services.AddControllers();
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