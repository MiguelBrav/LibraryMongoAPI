using LibraryMongo.Configurations;
using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Endpoints;
using LibraryMongo.Infrastructure.Repositories;
using LibraryMongo.Models.Entities;
using LibraryMongo.UseCases.Aggregators;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.CategoriesUseCases;
using LibraryMongo.UseCases.FeatureFlagsUseCases;
using LibraryMongo.UseCases.RoleUseCases;
using LibraryMongo.UseCases.UserUseCases;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
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

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/users/login";         
        options.LogoutPath = "/users/logout";        
        options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
        options.SlidingExpiration = true;
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));
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

builder.Services.AddHealthChecks().AddCheck<MongoCheck>("mongodb");

builder.Services.AddSingleton<IRoleRepository, RoleRepository>();
builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
builder.Services.AddSingleton<IFeatureFlagRepository, FeatureFlagRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddTransient<CreateRoleUseCase>();
builder.Services.AddTransient<UpdateRoleUseCase>();
builder.Services.AddTransient<DeleteRoleUseCase>();
builder.Services.AddTransient<GetAllRoleUseCase>();
builder.Services.AddTransient<GetByIdRoleUseCase>();
builder.Services.AddTransient<CreateCategoryUseCase>();
builder.Services.AddTransient<UpdateCategoryUseCase>();
builder.Services.AddTransient<DeleteCategoryUseCase>();
builder.Services.AddTransient<GetAllCategoryUseCase>();
builder.Services.AddTransient<GetByIdCategoryUseCase>();
builder.Services.AddTransient<GetAllFeatureFlagsUseCase>();
builder.Services.AddTransient<GetByIdFeatureFlagUseCase>();
builder.Services.AddTransient<CreateFeatureFlagUseCase>();
builder.Services.AddTransient<UpdateFeatureFlagUseCase>();
builder.Services.AddTransient<DeleteFeatureFlagUserCase>();
builder.Services.AddTransient<CreateUserUseCase>();
builder.Services.AddTransient<LoginUserUseCase>();
builder.Services.AddTransient<LogoutUserUseCase>();
builder.Services.AddTransient<DeleteUserUseCase>();
builder.Services.AddTransient<SetBannedUserUseCase>();
builder.Services.AddTransient<IRoleUseCaseAggregator, RoleUseCaseAggregator>();
builder.Services.AddTransient<ICategoryUseCaseAggregator, CategoryUseCaseAggregator>();
builder.Services.AddTransient<IFeatureFlagUseCaseAggregator, FeatureFlagUseCaseAggregator>();
builder.Services.AddTransient<IUserUseCaseAggregator, UserUseCaseAggregator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapHealthChecks("/healthz", new HealthCheckOptions
{
    ResponseWriter = HealthCheckResponse.WriteResponse
});

app.MapGroup("/roles").WithTags("Role").MapRoleEndpoints();

app.MapGroup("/categories").WithTags("Category").MapCategoryEndpoints();

app.MapGroup("/featureflags").WithTags("FeatureFlag").MapFeatureFlagEndpoints();

app.MapGroup("/users").WithTags("Users").MapUserEndpoints();

app.Run();
