using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LibraryMongo.Models;

public class User
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonRequired]
    public string Username { get; set; } = string.Empty;

    [BsonRequired]
    public string Password { get; set; } = string.Empty;

    [BsonRequired]
    public ObjectId RolId { get; set; } 

    [BsonRequired]
    public bool IsBanned { get; set; }

    [BsonRequired]
    public List<ObjectId> Favorites { get; set; } = new List<ObjectId>();

    [BsonRequired]
    public List<ObjectId> FeatureFlags { get; set; } = new List<ObjectId>();
}
