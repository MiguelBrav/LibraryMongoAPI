using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.Entities;
using LibraryMongo.Models.Responses;

namespace LibraryMongo.UseCases.CategoriesUseCases;

public class GetByIdCategoryUseCase : UseCaseBase<string>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetByIdCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public override async Task<IResult> Execute(string id)
    {
        try
        {
            Category _existingCategory = await _categoryRepository.GetById(id);

            if (_existingCategory is null)
            {
                return TypedResults.NotFound();
            }

            CategoryResponse roleResponse = new CategoryResponse(_existingCategory);

            return TypedResults.Ok(roleResponse);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}