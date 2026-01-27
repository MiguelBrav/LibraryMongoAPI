using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Infrastructure.Repositories;
using LibraryMongo.Models.Entities;
using LibraryMongo.Models.Responses;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.UserUseCases;

public class GetAllUserUseCase : UseCaseBase<Unit, IResult>
{
    private readonly IUserRepository _userRepository;

    private readonly IRoleRepository _roleRepository;

    public GetAllUserUseCase(IUserRepository userRepository, IConfiguration config, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public override async Task<IResult> Execute(Unit emptyRequest)
    {
        try
        {
            List<User> allUsers = await _userRepository.GetAllAsync();

            List<Role> roles = await _roleRepository.GetAllAsync();

            var roleDict = roles.ToDictionary(r => r.Id, r => r);

            List<UserResponse> allUsersResponse = allUsers.Select(user =>
            {
                roleDict.TryGetValue(user.RolId, out var role);

                return new UserResponse
                {
                    Id = user.Id.ToString(),
                    Username = user.Username,
                    RolName = role != null ? new RoleResponse(role) : new RoleResponse(),
                    IsBanned = user.IsBanned
                };
            }).ToList();

            return TypedResults.Ok(allUsersResponse);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}

