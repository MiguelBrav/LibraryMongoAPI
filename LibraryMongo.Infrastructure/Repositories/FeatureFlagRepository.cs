using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LibraryMongo.Infrastructure.Repositories;

public class FeatureFlagRepository : IFeatureFlagRepository
{
    private readonly IMongoCollection<FeatureFlag> _features;

    public FeatureFlagRepository(IMongoClient client, IConfiguration config)
    {
        var database = client.GetDatabase(config["MongoDb:DatabaseName"]);
        _features = database.GetCollection<FeatureFlag>("FeatureFlags");
    }

    public async Task<List<FeatureFlag>> GetAllAsync()
    {
        return await _features.Find(FilterDefinition<FeatureFlag>.Empty).ToListAsync();
    }
    public async Task<FeatureFlag> GetById(string id)
    {
        ObjectId objectId = ObjectId.Parse(id);
        FilterDefinition<FeatureFlag> filter = Builders<FeatureFlag>.Filter.Eq(r => r.Id, objectId);
        return await _features.Find(filter).FirstOrDefaultAsync();
    }

}
