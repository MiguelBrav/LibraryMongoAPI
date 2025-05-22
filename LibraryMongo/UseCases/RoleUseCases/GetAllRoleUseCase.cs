using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.Entities;
using LibraryMongo.Models.Responses;

namespace LibraryMongo.UseCases.RoleUseCases;

public class GetAllRoleUseCase : UseCaseBase<Unit>
{
    private readonly IRoleRepository _roleRepository;

    public GetAllRoleUseCase(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public override async Task<IResult> Execute(Unit emptyRequest)
    {
        try
        {
            List<Role> roles = await _roleRepository.GetAllAsync();

            List<RoleResponse> rolesResponse = roles.Select(role => new RoleResponse(role)).ToList();

            return TypedResults.Ok(rolesResponse);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}
