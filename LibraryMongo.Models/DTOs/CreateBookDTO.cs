using System.ComponentModel.DataAnnotations;

namespace LibraryMongo.Models.DTOs;

public class CreateBookDTO
{
    [Required]
    public Dictionary<string, string> Title { get; set; } = new Dictionary<string, string>();

    [Required]
    public string Author { get; set; } = string.Empty;

    [Required]
    public string CategoryId { get; set; } = string.Empty;

    public bool Available { get; set; } = true;

    [Range(0, 2100)]
    public int PublicationYear { get; set; }
}
