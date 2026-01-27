using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.FeatureFlagsUseCases;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class FeatureFlagUseCaseAggregator : IFeatureFlagUseCaseAggregator
{
    private readonly GetAllFeatureFlagsUseCase _getAllFeatureFlags;

    private readonly GetByIdFeatureFlagUseCase _getByIdFeatureFlag;

    private readonly CreateFeatureFlagUseCase _createFeatureFlagUseCase;

    private readonly UpdateFeatureFlagUseCase _updateFeatureFlagUseCase;

    private readonly DeleteFeatureFlagUserCase _deleteFeatureFlagUseCase;

    private readonly UseCaseDispatcher _useCaseDispatcher;


    public FeatureFlagUseCaseAggregator(GetAllFeatureFlagsUseCase getAllFeatureFlags, GetByIdFeatureFlagUseCase getByIdFeatureFlag,
        CreateFeatureFlagUseCase createFeatureFlagUseCase, UpdateFeatureFlagUseCase updateFeatureFlagUseCase, DeleteFeatureFlagUserCase deleteFeatureFlagUseCase, UseCaseDispatcher useCaseDispatcher)
    {
        _getAllFeatureFlags = getAllFeatureFlags;
        _getByIdFeatureFlag = getByIdFeatureFlag;
        _createFeatureFlagUseCase = createFeatureFlagUseCase;
        _updateFeatureFlagUseCase = updateFeatureFlagUseCase;
        _deleteFeatureFlagUseCase = deleteFeatureFlagUseCase;
        _useCaseDispatcher = useCaseDispatcher;
    }

    public async Task<IResult> CreateFeatureFlag(CreateFeatureFlagDTO request)
    {
        return await _useCaseDispatcher.Dispatch(_createFeatureFlagUseCase, request);
    }
    public async Task<IResult> UpdateFeatureFlag(UpdateFeatureFlagDTO request)
    {
        return await _useCaseDispatcher.Dispatch(_updateFeatureFlagUseCase, request);
    }
    public async Task<IResult> DeleteFeatureFlag(string id)
    {
        return await _useCaseDispatcher.Dispatch(_deleteFeatureFlagUseCase, id);
    }

    public async Task<IResult> GetAllFeatureFlags()
    {
        return await _useCaseDispatcher.Dispatch(_getAllFeatureFlags, Unit.Value);
    }
    public async Task<IResult> GetByIdFeatureFlag(string id)
    {
        return await _useCaseDispatcher.Dispatch(_getByIdFeatureFlag, id);
    }
}
