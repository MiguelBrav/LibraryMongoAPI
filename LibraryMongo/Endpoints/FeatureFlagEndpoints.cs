using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;

namespace LibraryMongo.Endpoints;

public static class FeatureFlagEndpoints
{
    public static RouteGroupBuilder MapFeatureFlagEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetAll);

        group.MapGet("/{id}", GetById);

        return group;
    }

    static async Task<IResult> GetAll(IFeatureFlagUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.GetAllFeatureFlags();
    }
    static async Task<IResult> GetById(string id, IFeatureFlagUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.GetByIdFeatureFlag(id);
    }
}