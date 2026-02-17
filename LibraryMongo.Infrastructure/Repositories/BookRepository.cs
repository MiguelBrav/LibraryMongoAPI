using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LibraryMongo.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly IMongoCollection<Book> _books;

    public BookRepository(IMongoClient client, IConfiguration config)
    {
        var database = client.GetDatabase(config["MongoDb:DatabaseName"]);
        _books = database.GetCollection<Book>("Books");
    }
    public async Task<ObjectId> CreateAsync(Book book)
    {
        await _books.InsertOneAsync(book);
        return book.Id;
    }

}
