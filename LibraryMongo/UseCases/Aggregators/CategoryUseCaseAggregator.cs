using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.CategoriesUseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class CategoryUseCaseAggregator : ICategoryUseCaseAggregator
{
    private readonly CreateCategoryUseCase _createCategory;

    public CategoryUseCaseAggregator(CreateCategoryUseCase createCategory)
    {
        _createCategory = createCategory;

    }
    public async Task<IResult> CreateCategory(CreateCategoryDTO request)
    {
        return await _createCategory.Execute(request);
    }
}
