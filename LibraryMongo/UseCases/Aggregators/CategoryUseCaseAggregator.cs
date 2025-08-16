using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.CategoriesUseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class CategoryUseCaseAggregator : ICategoryUseCaseAggregator
{
    private readonly CreateCategoryUseCase _createCategory;
    private readonly GetAllCategoryUseCase _getAllCategory;
    private readonly GetByIdCategoryUseCase _getByIdCategory;
    private readonly DeleteCategoryUseCase _deleteCategory;
    private readonly UpdateCategoryUseCase _updateCategory;
    public CategoryUseCaseAggregator(CreateCategoryUseCase createCategory, GetAllCategoryUseCase getAllCategory, GetByIdCategoryUseCase getByIdCategory, DeleteCategoryUseCase deleteCategory, UpdateCategoryUseCase updateCategory)
    {
        _createCategory = createCategory;
        _getAllCategory = getAllCategory;
        _getByIdCategory = getByIdCategory;
        _deleteCategory = deleteCategory;
        _updateCategory = updateCategory;
    }
    public async Task<IResult> CreateCategory(CreateCategoryDTO request)
    {
        return await _createCategory.Execute(request);
    }

    public async Task<IResult> UpdateCategory(UpdateCategoryDTO request)
    {
        return await _updateCategory.Execute(request);
    }

    public async Task<IResult> DeleteCategory(string id)
    {
        return await _deleteCategory.Execute(id);
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
