using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.Entities;
using LibraryMongo.Models.Responses;

namespace LibraryMongo.UseCases.FeatureFlagsUseCases;

public class GetAllFeatureFlagsUseCase : UseCaseBase<Unit>
{
    private readonly IFeatureFlagRepository _featureFlagRepository;

    public GetAllFeatureFlagsUseCase(IFeatureFlagRepository featureFlagRepository)
    {
        _featureFlagRepository = featureFlagRepository;
    }

    public override async Task<IResult> Execute(Unit emptyRequest)
    {
        try
        {
            List<FeatureFlag> featureFlags = await _featureFlagRepository.GetAllAsync();

            List<FeatureFlagResponse> rolesResponse = featureFlags.Select(flag => new FeatureFlagResponse(flag)).ToList();

            return TypedResults.Ok(rolesResponse);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}
