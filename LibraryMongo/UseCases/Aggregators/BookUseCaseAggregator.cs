using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.BooksUseCases;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class BookUseCaseAggregator : IBookUseCaseAggregator
{
    private readonly CreateBookUseCase _createBook;
    private readonly UpdateBookUseCase _updateBook;
    private readonly GetAllBookUseCase _getAllBooks;
    private readonly GetByIdBookUseCase _getByIdBook;

    private readonly UseCaseDispatcher _useCaseDispatcher;
    public BookUseCaseAggregator(CreateBookUseCase createBook, UpdateBookUseCase updateBook, GetAllBookUseCase getAllBooks, GetByIdBookUseCase getByIdBook, UseCaseDispatcher useCaseDispatcher)
    {
        _createBook = createBook;
        _updateBook = updateBook;
        _getAllBooks = getAllBooks;
        _getByIdBook = getByIdBook;
        _useCaseDispatcher = useCaseDispatcher;
    }
    public async Task<IResult> CreateBook(CreateBookDTO request)
    {
        return await _useCaseDispatcher.Dispatch(_createBook, request);
    }

    public async Task<IResult> UpdateBook(UpdateBookDTO request)
    {
        return await _useCaseDispatcher.Dispatch(_updateBook, request);
    }

    public async Task<IResult> GetAllBooks()
    {
        return await _useCaseDispatcher.Dispatch(_getAllBooks, Unit.Value);
    }

    public async Task<IResult> GetByIdBook(string id)
    {
        return await _useCaseDispatcher.Dispatch(_getByIdBook, id);
    }
}
