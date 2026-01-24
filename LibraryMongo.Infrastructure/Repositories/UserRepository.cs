using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LibraryMongo.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _users;

    public UserRepository(IMongoClient client, IConfiguration config)
    {
        var database = client.GetDatabase(config["MongoDb:DatabaseName"]);
        _users = database.GetCollection<User>("Users");
    }
    public async Task<ObjectId> CreateAsync(User user)
    {
        await _users.InsertOneAsync(user);
        return user.Id;
    }
    public async Task<bool> ExistsByUsernameAsync(string username)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Username, username);
        return await _users.Find(filter).AnyAsync();
    }
    public async Task<User> GetByUsernameAsync(string username)
    {
        return await _users.Find(u => u.Username == username).FirstOrDefaultAsync();
    }

    public async Task<User> GetById(string id)
    {
        ObjectId objectId = ObjectId.Parse(id);
        FilterDefinition<User> filter = Builders<User>.Filter.Eq(r => r.Id, objectId);
        return await _users.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<bool> DeleteAsync(string id)
    {
        ObjectId objectId = ObjectId.Parse(id);
        var filter = Builders<User>.Filter.Eq(r => r.Id, objectId);
        var result = await _users.DeleteOneAsync(filter);

        return result.IsAcknowledged && result.DeletedCount > 0;
    }
    public async Task<bool> SetBanStatusAsync(string id, bool isBanned)
    {
        ObjectId objectId = ObjectId.Parse(id);
        var filter = Builders<User>.Filter.Eq(u => u.Id, objectId);
        var update = Builders<User>.Update.Set(u => u.IsBanned, isBanned);

        var result = await _users.UpdateOneAsync(filter, update);

        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _users.Find(FilterDefinition<User>.Empty).ToListAsync();
    }
}
