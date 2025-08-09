using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Models.Entities;
using LibraryMongo.Models.Responses;

namespace LibraryMongo.UseCases.RoleUseCases;

public class GetByIdRoleUseCase : UseCaseBase<string>
{
    private readonly IRoleRepository _roleRepository;

    public GetByIdRoleUseCase(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public override async Task<IResult> Execute(string id)
    {
        try
        {
            Role _existingRole = await _roleRepository.GetById(id);

            if (_existingRole is null)
            {
                return TypedResults.NotFound();
            }

            RoleResponse roleResponse = new RoleResponse(_existingRole);

            return TypedResults.Ok(roleResponse);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}
