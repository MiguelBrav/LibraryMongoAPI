using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.Entities;
using LibraryMongo.Models.Responses;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.BooksUseCases;

public class GetByIdBookUseCase : UseCaseBase<string, IResult>
{
    private readonly IBookRepository _bookRepository;

    public GetByIdBookUseCase(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public override async Task<IResult> Execute(string id)
    {
        try
        {
            Book existingBook = await _bookRepository.GetById(id);

            if (existingBook is null)
            {
                return TypedResults.NotFound();
            }

            BookResponse bookResponse = new BookResponse(existingBook);

            return TypedResults.Ok(bookResponse);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}
