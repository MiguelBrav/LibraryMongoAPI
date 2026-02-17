using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.BooksUseCases;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class BookUseCaseAggregator : IBookUseCaseAggregator
{
    private readonly CreateBookUseCase _createBook;
 
    private readonly UseCaseDispatcher _useCaseDispatcher;
    public BookUseCaseAggregator(CreateBookUseCase createBook, UseCaseDispatcher useCaseDispatcher)
    {
        _createBook = createBook;
        _useCaseDispatcher = useCaseDispatcher;
    }
    public async Task<IResult> CreateBook(CreateBookDTO request)
    {
        return await _useCaseDispatcher.Dispatch(_createBook, request);
    }
}
