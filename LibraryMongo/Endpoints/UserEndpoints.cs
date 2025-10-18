using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;

namespace LibraryMongo.Endpoints;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/", Create);

        return group;
    }

    static async Task<IResult> Create(CreateUserDTO user, IUserUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.CreateUser(user);
    }
}