using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.DTOs;
using LibraryMongo.Models.Entities;
using MongoDB.Bson;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.BooksUseCases;

public class CreateBookUseCase : UseCaseBase<CreateBookDTO, IResult>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IBookRepository _bookRepository;

    public CreateBookUseCase(ICategoryRepository categoryRepository, IBookRepository bookRepository)
    {
        _categoryRepository = categoryRepository;
        _bookRepository = bookRepository;
    }

    public override async Task<IResult> Execute(CreateBookDTO request)
    {
        try
        {
            if (!request.Title.Any())
            {
                return TypedResults.BadRequest("Title dictionary is required and cannot be empty.");
            }

            Category validCategory = await _categoryRepository.GetById(request.CategoryId);

            if (validCategory == null)
            {
                return TypedResults.BadRequest("CategoryId is not valid");
            }

            Book book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                CategoryId = ObjectId.Parse(request.CategoryId),
                Available = request.Available,
                PublicationYear = request.PublicationYear
            };

            await _bookRepository.CreateAsync(book);

            return TypedResults.Created($"/books/{book.Id}", new { Name = book.Title, Id = book.Id.ToString() });
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}