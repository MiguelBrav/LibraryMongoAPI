using LibraryMongo.Models.DTOs;

namespace LibraryMongo.UseCases.Aggregators.Interfaces;

public interface IBookUseCaseAggregator
{  
    public Task<IResult> CreateBook(CreateBookDTO request);
}
