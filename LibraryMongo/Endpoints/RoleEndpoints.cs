using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;

namespace LibraryMongo.Endpoints;

public static class RoleEndpoints
{
    public static RouteGroupBuilder MapRoleEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/", Create);

        group.MapPut("/", Update);

        group.MapDelete("/{id}", Delete);

        group.MapGet("/", GetAll);

        return group;
    }

    static async Task<IResult> Create(CreateRoleDTO role, IRoleUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.CreateRole(role);
    }
    static async Task<IResult> Update(UpdateRoleDTO role, IRoleUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.UpdateRole(role);
    }
    static async Task<IResult> Delete(string id, IRoleUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.DeleteRole(id);
    }
    static async Task<IResult> GetAll(IRoleUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.GetAllRole();
    }

}