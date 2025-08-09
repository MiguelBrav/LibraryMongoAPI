using LibraryMongo.Models.Entities;

namespace LibraryMongo.Models.Responses;

public class CategoryResponse
{
    public string Id { get; set; } = string.Empty;
    public Dictionary<string, string> Name { get; set; } = new Dictionary<string, string>();

    public CategoryResponse() { }

    public CategoryResponse(Category cat)
    {
        Id = cat.Id.ToString();
        Name = cat.Name;
    }
}

