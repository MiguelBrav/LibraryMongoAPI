using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.Entities;

namespace LibraryMongo.UseCases.UserUseCases;

public class SetBannedUserUseCase : UseCaseBase<string>
{
    private readonly IUserRepository _userRepository;

    public SetBannedUserUseCase(IUserRepository userRepository, IConfiguration config)
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

            bool status = await _userRepository.SetBanStatusAsync(id, !_existingUser.IsBanned);

            if (!status)
            {
                return TypedResults.Problem("Failed to update the user status.");
            }

            return TypedResults.Ok("User status updated successfully.");

        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}

