using MediatR;
using System.Reflection;
using DailyTasks.Application.Features;
using DailyTasks.Domain.Entities;
using DailyTasks.Domain.Interfaces;
using DailyTasks.Infrastructure.RavenDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRepository<DailyTask>, DailyTaskRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(CreateDailyTaskCommandHandler).Assembly));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(DeleteDailyTaskCommandHandler).Assembly));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(GetDailyTaskByIdQueryHandler).Assembly));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(GetDailyTaskQueryHandler).Assembly));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(UpdateDailyTaskCommandHandler).Assembly));

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

