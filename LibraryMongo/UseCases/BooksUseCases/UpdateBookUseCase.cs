using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.DTOs;
using LibraryMongo.Models.Entities;
using MongoDB.Bson;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.BooksUseCases;

public class UpdateBookUseCase : UseCaseBase<UpdateBookDTO, IResult>
{
    private readonly IBookRepository _bookRepository;
    private readonly ICategoryRepository _categoryRepository;

    public UpdateBookUseCase(IBookRepository bookRepository, ICategoryRepository categoryRepository)
    {
        _bookRepository = bookRepository;
        _categoryRepository = categoryRepository;
    }

    public override async Task<IResult> Execute(UpdateBookDTO request)
    {
        try
        {
            if (request.Title == null || !request.Title.Any())
            {
                return TypedResults.BadRequest("Title dictionary is required and cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.Id))
            {
                return TypedResults.BadRequest("Id is required and cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.Author))
            {
                return TypedResults.BadRequest("Author is required and cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.CategoryId))
            {
                return TypedResults.BadRequest("CategoryId is required and cannot be empty.");
            }

            Book existingBook = await _bookRepository.GetById(request.Id);

            if (existingBook is null)
            {
                return TypedResults.NotFound();
            }

            Category validCategory = await _categoryRepository.GetById(request.CategoryId);

            if (validCategory == null)
            {
                return TypedResults.BadRequest("CategoryId is not valid");
            }

            Book book = new Book
            {
                Id = ObjectId.Parse(request.Id),
                Title = request.Title,
                Author = request.Author,
                CategoryId = ObjectId.Parse(request.CategoryId),
                Available = request.Available,
                PublicationYear = request.PublicationYear
            };

            bool isUpdated = await _bookRepository.UpdateAsync(book);

            if (!isUpdated)
            {
                return TypedResults.Ok("No changes were made to the book.");
            }

            return TypedResults.Ok(book);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}
