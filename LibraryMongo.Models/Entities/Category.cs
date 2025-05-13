using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LibraryMongo.Models.Entities;

public class Category
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonRequired]
    public Dictionary<string, string> Name { get; set; } = new Dictionary<string, string>();
}
