using LibraryMongo.Models.Entities;
using MongoDB.Bson;

namespace LibraryMongo.Domain.Interfaces;

public interface IRoleRepository
{
    Task <ObjectId> CreateAsync(Role role);
    Task <bool> UpdateAsync(Role role);
    Task<bool> DeleteAsync(string id);
    Task<List<Role>> GetAllAsync();
    Task<Role> GetById(string id);
    Task<Role> GetByNameAndLanguage(string name, string language);
}
