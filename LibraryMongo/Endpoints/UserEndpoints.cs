using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;

namespace LibraryMongo.Endpoints;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/", Create);

        group.MapPost("/login", Login);

        group.MapGet("/logout", Logout);

        group.MapDelete("/{id}", Delete);

        return group;
    }

    static async Task<IResult> Create(CreateUserDTO user, IUserUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.CreateUser(user);
    }
    static async Task<IResult> Login(LoginUserDTO user, IUserUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.LoginUser(user);
    }

    static async Task<IResult> Delete(string id, IUserUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.DeleteUser(id);
    }

    static async Task<IResult> Logout(IUserUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.LogoutUser();
    }
}