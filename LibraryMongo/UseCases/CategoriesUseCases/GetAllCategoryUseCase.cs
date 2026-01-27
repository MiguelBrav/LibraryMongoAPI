using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.Entities;
using LibraryMongo.Models.Responses;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.CategoriesUseCases;

public class GetAllCategoryUseCase : UseCaseBase<Unit, IResult>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public override async Task<IResult> Execute(Unit emptyRequest)
    {
        try
        {
            List<Category> categories = await _categoryRepository.GetAllAsync();

            List<CategoryResponse> rolesResponse = categories.Select(cat => new CategoryResponse(cat)).ToList();

            return TypedResults.Ok(rolesResponse);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}
