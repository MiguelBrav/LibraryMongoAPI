using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.Entities;
using LibraryMongo.Models.Responses;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.FeatureFlagsUseCases;

public class GetByIdFeatureFlagUseCase : UseCaseBase<string, IResult>
{
    private readonly IFeatureFlagRepository _featureFlagRepository;

    public GetByIdFeatureFlagUseCase(IFeatureFlagRepository featureFlagRepository)
    {
        _featureFlagRepository = featureFlagRepository;
    }

    public override async Task<IResult> Execute(string id)
    {
        try
        {
            FeatureFlag _featureFlag = await _featureFlagRepository.GetById(id);

            if (_featureFlag is null)
            {
                return TypedResults.NotFound();
            }

            FeatureFlagResponse flagResponse = new FeatureFlagResponse(_featureFlag);

            return TypedResults.Ok(flagResponse);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}