namespace LibraryMongo.Models.DTOs;

public class UpdateBookDTO
{
    public string Id { get; set; } = string.Empty;
    public Dictionary<string, string> Title { get; set; } = new Dictionary<string, string>();
    public string Author { get; set; } = string.Empty;
    public string CategoryId { get; set; } = string.Empty;
    public bool Available { get; set; } = true;
    public int PublicationYear { get; set; }
}
