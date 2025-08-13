using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;

namespace LibraryMongo.Endpoints;

public static class CategoryEndpoints
{
    public static RouteGroupBuilder MapCategoryEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/", Create);

        group.MapDelete("/{id}", Delete);

        group.MapGet("/", GetAll);

        group.MapGet("/{id}", GetById);

        return group;
    }

    static async Task<IResult> Create(CreateCategoryDTO category, ICategoryUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.CreateCategory(category);
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