using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryMongo.Endpoints;

public static class FeatureFlagEndpoints
{
    public static RouteGroupBuilder MapFeatureFlagEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/", Create);

        group.MapPut("/", Update);

        group.MapDelete("/{id}", Delete);

        group.MapGet("/", GetAll);

        group.MapGet("/{id}", GetById);

        return group;
    }

    static async Task<IResult> Create(CreateFeatureFlagDTO flag, IFeatureFlagUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.CreateFeatureFlag(flag);
    }
    static async Task<IResult> Update(UpdateFeatureFlagDTO flag, IFeatureFlagUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.UpdateFeatureFlag(flag);
    }
    static async Task<IResult> Delete(string id, IFeatureFlagUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.DeleteFeatureFlag(id);
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