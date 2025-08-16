using LibraryMongo.Models.Entities;
using MongoDB.Bson;

namespace LibraryMongo.Domain.Interfaces;

public interface ICategoryRepository
{
    Task <ObjectId> CreateAsync(Category category);
    Task<bool> UpdateAsync(Category role);
    Task<bool> DeleteAsync(string id);
    Task<List<Category>> GetAllAsync();
    Task<Category> GetById(string id);
}
