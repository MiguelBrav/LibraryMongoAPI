using LibraryMongo.Models.DTOs;

namespace LibraryMongo.UseCases.Aggregators.Interfaces;

public interface ICategoryUseCaseAggregator
{  
    public Task<IResult> CreateCategory(CreateCategoryDTO request);
    public Task<IResult> UpdateCategory(UpdateCategoryDTO request);
    public Task<IResult> DeleteCategory(string id);
    public Task<IResult> GetAllCategory();
    public Task<IResult> GetByIdCategory(string id);
}
