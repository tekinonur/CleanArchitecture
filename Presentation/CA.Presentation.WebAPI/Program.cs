using CA.Core.Domain.IRepositories.Base;
using CA.Infrastructure.IoC;
using CA.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Infrastructure.IoC.DependencyInjection
builder.Services.RegisterServices(builder.Configuration);

//Seed data
var unitOfWork = builder.Services.BuildServiceProvider().GetRequiredService<IUnitOfWork>();
await Seed.SeedData(unitOfWork);

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
