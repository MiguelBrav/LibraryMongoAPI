using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.DTOs;
using LibraryMongo.Models.Entities;
using MongoDB.Bson;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.FeatureFlagsUseCases;

public class UpdateFeatureFlagUseCase : UseCaseBase<UpdateFeatureFlagDTO, IResult>
{
    private readonly IFeatureFlagRepository _featureFlagRepository;

    public UpdateFeatureFlagUseCase(IFeatureFlagRepository featureFlagRepository)
    {
        _featureFlagRepository = featureFlagRepository;
    }

    public override async Task<IResult> Execute(UpdateFeatureFlagDTO request)
    {
        try
        {
            if (string.IsNullOrEmpty(request.Id))
            {
                return TypedResults.BadRequest("Id is required and cannot be empty.");
            }

            if (request.Name == null || !request.Name.Any())
            {
                return TypedResults.BadRequest("Name dictionary is required and cannot be empty.");
            }

            if (request.Description == null || !request.Description.Any())
            {
                return TypedResults.BadRequest("Description dictionary is required and cannot be empty.");
            }

            FeatureFlag flag = new FeatureFlag
            {
                Id = ObjectId.Parse(request.Id),
                Name = request.Name,
                Description = request.Description,
                Enabled = request.Enabled,
            };

            bool isUpdated = await _featureFlagRepository.UpdateAsync(flag);

            if (!isUpdated)
            {
                return TypedResults.Ok("No changes were made to the flag feature.");
            }

            return TypedResults.Ok(flag);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}
