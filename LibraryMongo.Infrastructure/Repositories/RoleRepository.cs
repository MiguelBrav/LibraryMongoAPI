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
}
