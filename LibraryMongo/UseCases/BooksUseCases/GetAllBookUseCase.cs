using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.Entities;
using LibraryMongo.Models.Responses;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.BooksUseCases;

public class GetAllBookUseCase : UseCaseBase<Unit, IResult>
{
    private readonly IBookRepository _bookRepository;

    public GetAllBookUseCase(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public override async Task<IResult> Execute(Unit emptyRequest)
    {
        try
        {
            List<Book> books = await _bookRepository.GetAllAsync();

            List<BookResponse> booksResponse = books.Select(b => new BookResponse(b)).ToList();

            return TypedResults.Ok(booksResponse);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}
