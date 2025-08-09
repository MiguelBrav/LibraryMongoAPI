using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.CategoriesUseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class CategoryUseCaseAggregator : ICategoryUseCaseAggregator
{
    private readonly CreateCategoryUseCase _createCategory;
    private readonly GetAllCategoryUseCase _getAllCategory;
    private readonly GetByIdCategoryUseCase _getByIdCategory;

    public CategoryUseCaseAggregator(CreateCategoryUseCase createCategory, GetAllCategoryUseCase getAllCategory, GetByIdCategoryUseCase getByIdCategory)
    {
        _createCategory = createCategory;
        _getAllCategory = getAllCategory;
        _getByIdCategory = getByIdCategory;
    }
    public async Task<IResult> CreateCategory(CreateCategoryDTO request)
    {
        return await _createCategory.Execute(request);
    }

    public async Task<IResult> GetAllCategory()
    {
        return await _getAllCategory.Execute(Unit.Value);
    }

    public async Task<IResult> GetByIdCategory(string id)
    {
        return await _getByIdCategory.Execute(id);
    }
}
