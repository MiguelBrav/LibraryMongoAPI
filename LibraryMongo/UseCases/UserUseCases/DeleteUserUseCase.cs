using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.Entities;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.UserUseCases;

public class DeleteUserUseCase : UseCaseBase<string,IResult>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserUseCase(IUserRepository userRepository, IConfiguration config)
    {
        _userRepository = userRepository;
    }

    public override async Task<IResult> Execute(string id)
    {
        try
        {
            if (string.IsNullOrEmpty(id))
            {
                return TypedResults.BadRequest("Id is required and cannot be empty.");
            }

            User _existingUser = await _userRepository.GetById(id);

            if (_existingUser is null)
            {
                return TypedResults.NotFound();
            }

            bool isDeleted = await _userRepository.DeleteAsync(id);

            if (!isDeleted)
            {
                return TypedResults.Problem("Failed to delete the user.");
            }

            return TypedResults.Ok("User deleted successfully.");
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}

