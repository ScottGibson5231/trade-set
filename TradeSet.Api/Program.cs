using Microsoft.EntityFrameworkCore;
using TradeSet.Core;
using TradeSet.Services;
using TradeSet.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<IEmployerService, EmployerService>();

builder.Services.AddDbContext<TradeSetDbContext>(opt =>
 opt.UseNpgsql(builder.Configuration.GetValue<string>("TradeSetDbConnectionString")));
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
