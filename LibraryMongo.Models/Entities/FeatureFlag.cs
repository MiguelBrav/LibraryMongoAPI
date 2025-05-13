using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LibraryMongo.Models.Entities;

public class FeatureFlag
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonRequired]
    public Dictionary<string, string> Name { get; set; } = new Dictionary<string, string>();

    [BsonRequired]
    public Dictionary<string, string> Description { get; set; } = new Dictionary<string, string>();

    [BsonRequired]
    public bool Enabled { get; set; } 
}
