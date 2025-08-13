using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.Entities;

namespace LibraryMongo.UseCases.CategoriesUseCases;

public class DeleteCategoryUseCase : UseCaseBase<string>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryUseCase(ICategoryRepository categoryRepository)
    {
    _categoryRepository = categoryRepository;
    }

    public override async Task<IResult> Execute(string id)
    {
        try
        {
            if (string.IsNullOrEmpty(id))
            {
                return TypedResults.BadRequest("Id is required and cannot be empty.");
            }

            Category _existingCategory = await _categoryRepository.GetById(id);

            if (_existingCategory is null)
            {
                return TypedResults.NotFound();
            }

            bool isDeleted = await _categoryRepository.DeleteAsync(id);

            if (!isDeleted)
            {
                return TypedResults.Problem("Failed to delete the role.");
            }

            return TypedResults.Ok("Category deleted successfully.");
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}
