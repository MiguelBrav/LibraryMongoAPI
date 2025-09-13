using LibraryMongo.Models.Entities;
using MongoDB.Bson;

namespace LibraryMongo.Domain.Interfaces;

public interface IFeatureFlagRepository
{
    Task<ObjectId> CreateAsync(FeatureFlag featureFlag);
    Task<List<FeatureFlag>> GetAllAsync();
    Task<FeatureFlag> GetById(string id);
}
