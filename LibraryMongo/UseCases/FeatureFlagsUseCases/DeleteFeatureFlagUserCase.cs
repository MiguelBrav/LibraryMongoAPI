using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.Entities;

namespace LibraryMongo.UseCases.FeatureFlagsUseCases;

public class DeleteFeatureFlagUserCase : UseCaseBase<string>
{
    private readonly IFeatureFlagRepository _featureFlagRepository;

    public DeleteFeatureFlagUserCase(IFeatureFlagRepository featureFlagRepository)
    {
        _featureFlagRepository = featureFlagRepository;
    }

    public override async Task<IResult> Execute(string id)
    {
        try
        {
            if (string.IsNullOrEmpty(id))
            {
                return TypedResults.BadRequest("Id is required and cannot be empty.");
            }

            FeatureFlag _existingFlag = await _featureFlagRepository.GetById(id);

            if (_existingFlag is null)
            {
                return TypedResults.NotFound();
            }

            bool isDeleted = await _featureFlagRepository.DeleteAsync(id);

            if (!isDeleted)
            {
                return TypedResults.Problem("Failed to delete the role.");
            }

            return TypedResults.Ok("Feature Flag deleted successfully.");
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}
