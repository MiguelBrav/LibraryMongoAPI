using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.FeatureFlagsUseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class FeatureFlagUseCaseAggregator : IFeatureFlagUseCaseAggregator
{
    private readonly GetAllFeatureFlagsUseCase _getAllFeatureFlags;

    public FeatureFlagUseCaseAggregator(GetAllFeatureFlagsUseCase getAllFeatureFlags)
    {
        _getAllFeatureFlags = getAllFeatureFlags;
    }

    public async Task<IResult> GetAllFeatureFlags()
    {
        return await _getAllFeatureFlags.Execute(Unit.Value);
    }

}
