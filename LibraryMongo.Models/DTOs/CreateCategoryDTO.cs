namespace LibraryMongo.Models.DTOs;

public class CreateCategoryDTO
{
    public Dictionary<string, string> Name { get; set; } = new Dictionary<string, string>();
}
