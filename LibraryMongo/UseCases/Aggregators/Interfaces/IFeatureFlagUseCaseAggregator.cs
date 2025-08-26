using LibraryMongo.Models.DTOs;

namespace LibraryMongo.UseCases.Aggregators.Interfaces;

public interface IFeatureFlagUseCaseAggregator
{  
    public Task<IResult> GetAllFeatureFlags();
}
