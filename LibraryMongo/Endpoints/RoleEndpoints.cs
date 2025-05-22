using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;

namespace LibraryMongo.Endpoints;

public static class RoleEndpoints
{
    public static RouteGroupBuilder MapRoleEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/", Create);

        group.MapGet("/", GetAll);

        return group;
    }

    static async Task<IResult> Create(CreateRoleDTO role, IRoleUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.CreateRole(role);
    }
    static async Task<IResult> GetAll(IRoleUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.GetAllRole();
    }

}