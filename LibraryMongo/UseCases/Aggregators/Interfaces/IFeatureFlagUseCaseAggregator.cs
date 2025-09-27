using LibraryMongo.Models.DTOs;

namespace LibraryMongo.UseCases.Aggregators.Interfaces;

public interface IFeatureFlagUseCaseAggregator
{
    public Task<IResult> CreateFeatureFlag(CreateFeatureFlagDTO request);
    public Task<IResult> UpdateFeatureFlag(UpdateFeatureFlagDTO request);
    public Task<IResult> DeleteFeatureFlag(string id);
    public Task<IResult> GetAllFeatureFlags();
    public Task<IResult> GetByIdFeatureFlag(string id);

}
