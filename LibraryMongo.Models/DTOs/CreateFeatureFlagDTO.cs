namespace LibraryMongo.Models.DTOs;

public class CreateFeatureFlagDTO
{
    public Dictionary<string, string> Name { get; set; } = new Dictionary<string, string>();

    public Dictionary<string, string> Description { get; set; } = new Dictionary<string, string>();

    public bool Enabled { get; set; } = false;
}
