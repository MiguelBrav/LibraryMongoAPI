using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LibraryMongo.Models.Entities;

public class FeatureFlag
{
    [BsonElement("id")]
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("name")]
    [BsonRequired]
    public Dictionary<string, string> Name { get; set; } = new Dictionary<string, string>();

    [BsonElement("description")]
    [BsonRequired]
    public Dictionary<string, string> Description { get; set; } = new Dictionary<string, string>();

    [BsonElement("enabled")]
    [BsonRequired]
    public bool Enabled { get; set; } 
}
