using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;

namespace LibraryMongo.Endpoints;

public static class CategoryEndpoints
{
    public static RouteGroupBuilder MapCategoryEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/", Create).RequireAuthorization("AdminOnly");

        group.MapPut("/", Update).RequireAuthorization("AdminOnly");

        group.MapDelete("/{id}", Delete).RequireAuthorization("AdminOnly");

        group.MapGet("/", GetAll).RequireAuthorization();

        group.MapGet("/{id}", GetById).RequireAuthorization();

        return group;
    }

    static async Task<IResult> Create(CreateCategoryDTO category, ICategoryUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.CreateCategory(category);
    }

    static async Task<IResult> Update(UpdateCategoryDTO category, ICategoryUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.UpdateCategory(category);
    }

    static async Task<IResult> Delete(string id, ICategoryUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.DeleteCategory(id);
    }

    static async Task<IResult> GetAll(ICategoryUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.GetAllCategory();
    }

    static async Task<IResult> GetById(string id, ICategoryUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.GetByIdCategory(id);
    }
}