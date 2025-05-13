using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LibraryMongo.Models.Entities;

public class Role
{
    [BsonElement("id")]
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("name")]
    [BsonRequired]
    public Dictionary<string, string> Name { get; set; } = new Dictionary<string, string>();
}
