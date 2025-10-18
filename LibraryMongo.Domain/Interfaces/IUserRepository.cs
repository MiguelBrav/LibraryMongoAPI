using LibraryMongo.Models.Entities;
using MongoDB.Bson;

namespace LibraryMongo.Domain.Interfaces;

public interface IUserRepository
{
    Task <ObjectId> CreateAsync(User user);
    Task<bool> ExistsByUsernameAsync(string username);
}

