using Microsoft.EntityFrameworkCore;
using FluentValidation;
using User.App.Repositories;
using User.App.Requests;
using User.Core.Abstractions.Repositories;
using User.DAL;
using User.App.Validators;
using MediatR;
using User.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetClientByIdHandler).Assembly));
builder.Services.AddValidatorsFromAssemblyContaining<ClientValidator>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
builder.Services.AddScoped<HttpClient>();
var app = builder.Build();
app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.Run();

//ловить исключения
//добавить регистрацию и авторизацию
//внедрить логирование
//написать юнит-тесты
//имплементировать брокеры сообщений для событий
//заменить строки подключения и запросов
