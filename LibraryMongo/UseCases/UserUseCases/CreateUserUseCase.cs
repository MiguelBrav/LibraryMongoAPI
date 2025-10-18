using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Helpers;
using LibraryMongo.Models.DTOs;
using LibraryMongo.Models.Entities;
using MongoDB.Bson;

namespace LibraryMongo.UseCases.UserUseCases;

public class CreateUserUseCase : UseCaseBase<CreateUserDTO>
{
    private readonly IRoleRepository _roleRepository;

    private readonly IUserRepository _userRepository;

    private readonly string _defaultLang;
    private readonly string _defaultRole;

    public CreateUserUseCase(IRoleRepository roleRepository, IUserRepository userRepository, IConfiguration config)
    {
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _defaultLang = config["Defaults:Language"] ?? string.Empty;
        _defaultRole = config["Defaults:Role"] ?? string.Empty;
    }

    public override async Task<IResult> Execute(CreateUserDTO request)
    {
        try
        {
            string hashedPassword = PasswordHelper.HashPassword(request.Password);

            Role userRole = await _roleRepository.GetByNameAndLanguage(_defaultRole, _defaultLang);

            if (userRole is null)
            {
                return TypedResults.Problem("User role does not exists");
            }

            if (await _userRepository.ExistsByUsernameAsync(request.Username))
            {
                return TypedResults.Conflict($"A user with username '{request.Username}' already exists.");
            }

            var user = new User
            {
                Username = request.Username,
                Password = hashedPassword,
                RolId = userRole.Id,
                IsBanned = false,
                Favorites = new List<ObjectId>(),
                FeatureFlags = new List<ObjectId>()
            };

            await _userRepository.CreateAsync(user);

            return TypedResults.Created($"/user/{user.Id}", request);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}

