using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;

namespace LibraryMongo.Endpoints;

public static class BooksEndpoints
{
    public static RouteGroupBuilder MapBooksEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/", Create).RequireAuthorization("AdminOnly");
        group.MapPut("/", Update).RequireAuthorization("AdminOnly");
        group.MapGet("/", GetAll).RequireAuthorization();
        group.MapGet("/{id}", GetById).RequireAuthorization();

        return group;
    }

    static async Task<IResult> Create(CreateBookDTO book, IBookUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.CreateBook(book);
    }

    static async Task<IResult> Update(UpdateBookDTO book, IBookUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.UpdateBook(book);
    }

    static async Task<IResult> GetAll(IBookUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.GetAllBooks();
    }

    static async Task<IResult> GetById(string id, IBookUseCaseAggregator useCase, HttpContext httpContext)
    {
        return await useCase.GetByIdBook(id);
    }
}