using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryMongo.Endpoints;

public static class FeatureFlagEndpoints
{
    public static RouteGroupBuilder MapFeatureFlagEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/", Create);

        group.MapGet("/", GetAll);

        group.MapGet("/{id}", GetById);

        return group;
    }

    static async Task<IResult> Create(CreateFeatureFlagDTO flag, IFeatureFlagUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.CreateFeatureFlag(flag);
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