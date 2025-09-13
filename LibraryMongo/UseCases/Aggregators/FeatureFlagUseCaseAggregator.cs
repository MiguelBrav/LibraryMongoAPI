using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.FeatureFlagsUseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class FeatureFlagUseCaseAggregator : IFeatureFlagUseCaseAggregator
{
    private readonly GetAllFeatureFlagsUseCase _getAllFeatureFlags;

    private readonly GetByIdFeatureFlagUseCase _getByIdFeatureFlag;

    private readonly CreateFeatureFlagUseCase _createFeatureFlagUseCase;

    public FeatureFlagUseCaseAggregator(GetAllFeatureFlagsUseCase getAllFeatureFlags, GetByIdFeatureFlagUseCase getByIdFeatureFlag, CreateFeatureFlagUseCase createFeatureFlagUseCase)
    {
        _getAllFeatureFlags = getAllFeatureFlags;
        _getByIdFeatureFlag = getByIdFeatureFlag;
        _createFeatureFlagUseCase = createFeatureFlagUseCase;
    }

    public async Task<IResult> CreateFeatureFlag(CreateFeatureFlagDTO request)
    {
        return await _createFeatureFlagUseCase.Execute(request);
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
