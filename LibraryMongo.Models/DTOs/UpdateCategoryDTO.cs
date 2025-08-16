namespace LibraryMongo.Models.DTOs;

public class UpdateCategoryDTO
{
    public string Id { get; set; } = string.Empty;
    public Dictionary<string, string> Name { get; set; } = new Dictionary<string, string>();
}
