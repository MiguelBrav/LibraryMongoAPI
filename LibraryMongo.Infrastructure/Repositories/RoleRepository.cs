using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LibraryMongo.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly IMongoCollection<Role> _roles;

    public RoleRepository(IMongoClient client, IConfiguration config)
    {
        var database = client.GetDatabase(config["MongoDb:DatabaseName"]);
        _roles = database.GetCollection<Role>("Roles");
    }
    public async Task<ObjectId> CreateAsync(Role role)
    {
        await _roles.InsertOneAsync(role);
        return role.Id;
    }

    public async Task<bool> UpdateAsync(Role role)
    {
        FilterDefinition<Role> filter = Builders<Role>.Filter.Eq(r => r.Id, role.Id);
        var result = await _roles.ReplaceOneAsync(filter, role);

        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        ObjectId objectId = ObjectId.Parse(id);
        var filter = Builders<Role>.Filter.Eq(r => r.Id, objectId);
        var result = await _roles.DeleteOneAsync(filter);

        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<List<Role>> GetAllAsync()
    {
        return await _roles.Find(FilterDefinition<Role>.Empty).ToListAsync();
    }

    public async Task<Role> GetById(string id)
    {
        ObjectId objectId = ObjectId.Parse(id);
        FilterDefinition<Role> filter = Builders<Role>.Filter.Eq(r => r.Id, objectId);
        return await _roles.Find(filter).FirstOrDefaultAsync();
    }
}
