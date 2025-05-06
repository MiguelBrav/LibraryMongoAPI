using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LibraryMongo.Models;

public class Role
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonRequired]
    public Dictionary<string, string> Name { get; set; } = new Dictionary<string, string>();
}
