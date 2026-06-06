using LibraryMongo.Models.DTOs;

namespace LibraryMongo.UseCases.Aggregators.Interfaces;

public interface IBookUseCaseAggregator
{  
    public Task<IResult> CreateBook(CreateBookDTO request);
    public Task<IResult> UpdateBook(UpdateBookDTO request);
    public Task<IResult> GetAllBooks();
    public Task<IResult> GetByIdBook(string id);
}
