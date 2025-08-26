using LibraryMongo.Models.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace LibraryMongo.Models.Responses;

public class FeatureFlagResponse
{
    public string Id { get; set; } = string.Empty;
    public Dictionary<string, string> Name { get; set; } = new Dictionary<string, string>();
    public Dictionary<string, string> Description { get; set; } = new Dictionary<string, string>();
    public bool Enabled { get; set; }

    public FeatureFlagResponse() { }

    public FeatureFlagResponse(FeatureFlag feature)
    {
        Id = feature.Id.ToString();
        Name = feature.Name;
        Description = feature.Description;
        Enabled = feature.Enabled;
    }
}

