using Microsoft.EntityFrameworkCore;
using TASK_poiner.models;
using TASK_poiner.Repository.Employees;
using TASK_poiner.Repository.property;
using TASK_poiner.Service.Employees;
using TASK_poiner.Service.Propertys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaskContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
});
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IEmployeePropertyService, EmployeePropertyService>();
builder.Services.AddScoped<IPropertyService, PropertyService>();

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
