using LibraryMongo.Models.Entities;

namespace LibraryMongo.Models.Responses;

public class BookResponse
{
    public string Id { get; set; } = string.Empty;
    public Dictionary<string, string> Title { get; set; } = new Dictionary<string, string>();
    public string Author { get; set; } = string.Empty;
    public string CategoryId { get; set; } = string.Empty;
    public bool Available { get; set; }
    public int PublicationYear { get; set; }

    public BookResponse() { }

    public BookResponse(Book book)
    {
        Id = book.Id.ToString();
        Title = book.Title;
        Author = book.Author;
        CategoryId = book.CategoryId.ToString();
        Available = book.Available;
        PublicationYear = book.PublicationYear;
    }
}
