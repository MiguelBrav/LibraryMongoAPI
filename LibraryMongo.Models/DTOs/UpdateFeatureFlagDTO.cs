namespace LibraryMongo.Models.DTOs;

public class UpdateFeatureFlagDTO
{
    public string Id { get; set; } = string.Empty;

    public Dictionary<string, string> Name { get; set; } = new Dictionary<string, string>();

    public Dictionary<string, string> Description { get; set; } = new Dictionary<string, string>();

    public bool Enabled { get; set; } = false;
}
