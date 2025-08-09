using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LibraryMongo.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IMongoCollection<Category> _categories;

    public CategoryRepository(IMongoClient client, IConfiguration config)
    {
        var database = client.GetDatabase(config["MongoDb:DatabaseName"]);
        _categories = database.GetCollection<Category>("Categories");
    }
    public async Task<ObjectId> CreateAsync(Category category)
    {
        await _categories.InsertOneAsync(category);
        return category.Id;
    }
    public async Task<List<Category>> GetAllAsync()
    {
        return await _categories.Find(FilterDefinition<Category>.Empty).ToListAsync();
    }
    public async Task<Category> GetById(string id)
    {
        ObjectId objectId = ObjectId.Parse(id);
        FilterDefinition<Category> filter = Builders<Category>.Filter.Eq(r => r.Id, objectId);
        return await _categories.Find(filter).FirstOrDefaultAsync();
    }

}
