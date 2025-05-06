using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LibraryMongo.Models;

public class Book
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonRequired]
    public Dictionary<string, string> Title { get; set; } = new Dictionary<string, string>();

    [BsonRequired]
    public string Author { get; set; } = string.Empty;
     
    [BsonRequired]
    public ObjectId CategoryId { get; set; } 

    [BsonRequired]
    public bool Available { get; set; }

    [BsonRequired]
    public int PublicationYear { get; set; }
}
