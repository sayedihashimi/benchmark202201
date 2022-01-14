using Microsoft.Extensions.Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiContext")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration["benchmarkapi01:blob"], preferMsi: true);
    clientBuilder.AddQueueServiceClient(builder.Configuration["benchmarkapi01:queue"], preferMsi: true);
});

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
