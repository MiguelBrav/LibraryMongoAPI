using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.FeatureFlagsUseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class FeatureFlagUseCaseAggregator : IFeatureFlagUseCaseAggregator
{
    private readonly GetAllFeatureFlagsUseCase _getAllFeatureFlags;

    private readonly GetByIdFeatureFlagUseCase _getByIdFeatureFlag;

    public FeatureFlagUseCaseAggregator(GetAllFeatureFlagsUseCase getAllFeatureFlags, GetByIdFeatureFlagUseCase getByIdFeatureFlag)
    {
        _getAllFeatureFlags = getAllFeatureFlags;
        _getByIdFeatureFlag = getByIdFeatureFlag;
    }

    public async Task<IResult> GetAllFeatureFlags()
    {
        return await _getAllFeatureFlags.Execute(Unit.Value);
    }
    public async Task<IResult> GetByIdFeatureFlag(string id)
    {
        return await _getByIdFeatureFlag.Execute(id);
    }
}
