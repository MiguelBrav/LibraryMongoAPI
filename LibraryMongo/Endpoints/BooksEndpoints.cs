using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;

namespace LibraryMongo.Endpoints;

public static class BooksEndpoints
{
    public static RouteGroupBuilder MapBooksEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/", Create).RequireAuthorization("AdminOnly");

        return group;
    }

    static async Task<IResult> Create(CreateBookDTO book, IBookUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.CreateBook(book);
    }
}