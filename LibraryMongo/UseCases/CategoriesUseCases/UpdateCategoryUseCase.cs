using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Infrastructure.Repositories;
using LibraryMongo.Models.DTOs;
using LibraryMongo.Models.Entities;
using MongoDB.Bson;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.CategoriesUseCases;

public class UpdateCategoryUseCase : UseCaseBase<UpdateCategoryDTO, IResult>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public override async Task<IResult> Execute(UpdateCategoryDTO request)
    {
        try
        {
            if (request.Name == null || !request.Name.Any())
            {
                return TypedResults.BadRequest("Name dictionary is required and cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.Id))
            {
                return TypedResults.BadRequest("Id is required and cannot be empty.");
            }

            Category _existingCategory = await _categoryRepository.GetById(request.Id);

            if (_existingCategory is null)
            {
                return TypedResults.NotFound();
            }

            Category category = new Category
            {
                Name = request.Name,
                Id = ObjectId.Parse(request.Id)
            };

            bool isUpdated = await _categoryRepository.UpdateAsync(category);

            if (!isUpdated)
            {
                return TypedResults.Ok("No changes were made to the category.");
            }

            return TypedResults.Ok(category);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}
