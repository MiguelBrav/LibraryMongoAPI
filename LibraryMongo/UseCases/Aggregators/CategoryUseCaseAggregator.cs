using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.CategoriesUseCases;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class CategoryUseCaseAggregator : ICategoryUseCaseAggregator
{
    private readonly CreateCategoryUseCase _createCategory;
    private readonly GetAllCategoryUseCase _getAllCategory;
    private readonly GetByIdCategoryUseCase _getByIdCategory;
    private readonly DeleteCategoryUseCase _deleteCategory;
    private readonly UpdateCategoryUseCase _updateCategory;

    private readonly UseCaseDispatcher _useCaseDispatcher;
    public CategoryUseCaseAggregator(CreateCategoryUseCase createCategory, GetAllCategoryUseCase getAllCategory, GetByIdCategoryUseCase getByIdCategory, DeleteCategoryUseCase deleteCategory, UpdateCategoryUseCase updateCategory, UseCaseDispatcher useCaseDispatcher)
    {
        _createCategory = createCategory;
        _getAllCategory = getAllCategory;
        _getByIdCategory = getByIdCategory;
        _deleteCategory = deleteCategory;
        _updateCategory = updateCategory;
        _useCaseDispatcher = useCaseDispatcher;
    }
    public async Task<IResult> CreateCategory(CreateCategoryDTO request)
    {
        return await _useCaseDispatcher.Dispatch(_createCategory,request);
    }

    public async Task<IResult> UpdateCategory(UpdateCategoryDTO request)
    {
        return await _useCaseDispatcher.Dispatch(_updateCategory, request);

    }

    public async Task<IResult> DeleteCategory(string id)
    {
        return await _useCaseDispatcher.Dispatch(_deleteCategory, id);
    }

    public async Task<IResult> GetAllCategory()
    {
        return await _useCaseDispatcher.Dispatch(_getAllCategory, Unit.Value);
    }

    public async Task<IResult> GetByIdCategory(string id)
    {
        return await _useCaseDispatcher.Dispatch(_getByIdCategory, id);
    }
}
