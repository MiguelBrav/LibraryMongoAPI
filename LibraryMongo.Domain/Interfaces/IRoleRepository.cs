using LibraryMongo.Models.Entities;
using MongoDB.Bson;

namespace LibraryMongo.Domain.Interfaces;

public interface IRoleRepository
{
    Task <ObjectId> CreateAsync(Role role);  
}
