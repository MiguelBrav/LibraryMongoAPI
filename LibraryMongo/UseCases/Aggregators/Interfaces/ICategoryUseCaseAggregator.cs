using LibraryMongo.Models.DTOs;

namespace LibraryMongo.UseCases.Aggregators.Interfaces;

public interface ICategoryUseCaseAggregator
{  
    public Task<IResult> CreateCategory(CreateCategoryDTO request);
}
