using LibraryMongo.Models.Entities;
using MongoDB.Bson;

namespace LibraryMongo.Domain.Interfaces;

public interface IBookRepository
{
    Task <ObjectId> CreateAsync(Book category);
    Task<List<Book>> GetAllAsync();
    Task<Book> GetById(string id);
    Task<bool> UpdateAsync(Book book);
}
