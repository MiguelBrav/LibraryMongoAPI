using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Endpoints;
using LibraryMongo.Infrastructure.Repositories;
using LibraryMongo.Models.Entities;
using LibraryMongo.UseCases.Aggregators;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.RoleUseCases;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    return new MongoClient(config["MongoDb:ConnectionString"]);
});

builder.Services.AddSingleton<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<CreateRoleUseCase>();
builder.Services.AddTransient<UpdateRoleUseCase>();
builder.Services.AddTransient<DeleteRoleUseCase>();
builder.Services.AddTransient<GetAllRoleUseCase>();
builder.Services.AddTransient<GetByIdRoleUseCase>();
builder.Services.AddTransient<IRoleUseCaseAggregator, RoleUseCaseAggregator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.MapGroup("/roles").WithTags("Role").MapRoleEndpoints();

app.Run();
