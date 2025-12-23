using LibraryMongo.Models.Entities;
using MongoDB.Bson;

namespace LibraryMongo.Domain.Interfaces;

public interface IUserRepository
{
    Task <ObjectId> CreateAsync(User user);
    Task<bool> ExistsByUsernameAsync(string username);
    Task<User> GetByUsernameAsync(string username);
    Task<User> GetById(string id);
    Task<bool> DeleteAsync(string id);
    Task<bool> SetBanStatusAsync(string id, bool isBanned);

}

