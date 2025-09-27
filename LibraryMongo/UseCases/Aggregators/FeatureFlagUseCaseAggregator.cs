using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.FeatureFlagsUseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class FeatureFlagUseCaseAggregator : IFeatureFlagUseCaseAggregator
{
    private readonly GetAllFeatureFlagsUseCase _getAllFeatureFlags;

    private readonly GetByIdFeatureFlagUseCase _getByIdFeatureFlag;

    private readonly CreateFeatureFlagUseCase _createFeatureFlagUseCase;

    private readonly UpdateFeatureFlagUseCase _updateFeatureFlagUseCase;

    private readonly DeleteFeatureFlagUserCase _deleteFeatureFlagUseCase;

    public FeatureFlagUseCaseAggregator(GetAllFeatureFlagsUseCase getAllFeatureFlags, GetByIdFeatureFlagUseCase getByIdFeatureFlag,
        CreateFeatureFlagUseCase createFeatureFlagUseCase, UpdateFeatureFlagUseCase updateFeatureFlagUseCase, DeleteFeatureFlagUserCase deleteFeatureFlagUseCase)
    {
        _getAllFeatureFlags = getAllFeatureFlags;
        _getByIdFeatureFlag = getByIdFeatureFlag;
        _createFeatureFlagUseCase = createFeatureFlagUseCase;
        _updateFeatureFlagUseCase = updateFeatureFlagUseCase;
        _deleteFeatureFlagUseCase = deleteFeatureFlagUseCase;
    }

    public async Task<IResult> CreateFeatureFlag(CreateFeatureFlagDTO request)
    {
        return await _createFeatureFlagUseCase.Execute(request);
    }
    public async Task<IResult> UpdateFeatureFlag(UpdateFeatureFlagDTO request)
    {
        return await _updateFeatureFlagUseCase.Execute(request);
    }
    public async Task<IResult> DeleteFeatureFlag(string id)
    {
        return await _deleteFeatureFlagUseCase.Execute(id);
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
