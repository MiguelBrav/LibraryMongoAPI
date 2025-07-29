using LibraryMongo.Models.Entities;
using MongoDB.Bson;

namespace LibraryMongo.Domain.Interfaces;

public interface ICategoryRepository
{
    Task <ObjectId> CreateAsync(Category role);
}
