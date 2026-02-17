using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LibraryMongo.Models.Entities;

public class Book
{
    [BsonElement("id")]
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("title")]
    [BsonRequired]
    public Dictionary<string, string> Title { get; set; } = new Dictionary<string, string>();

    [BsonElement("author")]
    [BsonRequired]
    public string Author { get; set; } = string.Empty;

    [BsonElement("categoryId")]
    [BsonRequired]
    public ObjectId CategoryId { get; set; }

    [BsonElement("available")]
    [BsonRequired]
    public bool Available { get; set; }

    [BsonElement("publicationYear")]
    [BsonRequired]
    public int PublicationYear { get; set; }
}
