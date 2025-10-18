using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LibraryMongo.Models.Entities;

public class User
{
    [BsonElement("id")]
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("username")]
    [BsonRequired]
    public string Username { get; set; } = string.Empty;

    [BsonElement("password")]
    [BsonRequired]
    public string Password { get; set; } = string.Empty;

    [BsonElement("rolId")]
    [BsonRequired]
    public ObjectId RolId { get; set; }

    [BsonElement("isBanned")]
    [BsonRequired]
    public bool IsBanned { get; set; }

    [BsonElement("favorites")]
    [BsonRequired]
    public List<ObjectId> Favorites { get; set; } = new List<ObjectId>();

    [BsonElement("featureFlags")]
    [BsonRequired]
    public List<ObjectId> FeatureFlags { get; set; } = new List<ObjectId>();
}
