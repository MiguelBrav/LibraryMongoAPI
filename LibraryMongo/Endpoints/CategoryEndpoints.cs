using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;

namespace LibraryMongo.Endpoints;

public static class CategoryEndpoints
{
    public static RouteGroupBuilder MapCategoryEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/", Create);

        return group;
    }

    static async Task<IResult> Create(CreateCategoryDTO category, ICategoryUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.CreateCategory(category);
    }  

}