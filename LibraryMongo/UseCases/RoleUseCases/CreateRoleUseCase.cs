using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Infrastructure.Repositories;
using LibraryMongo.Models.DTOs;
using LibraryMongo.Models.Entities;

namespace LibraryMongo.UseCases.RoleUseCases;

public class CreateRoleUseCase : UseCaseBase<CreateRoleDTO>
{
    private readonly IRoleRepository _roleRepository;

    public CreateRoleUseCase(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public override async Task<IResult> Execute(CreateRoleDTO request)
    {
        try
        {
            if (request.Name == null || !request.Name.Any())
            {
                return TypedResults.BadRequest("Name dictionary is required and cannot be empty.");
            }

            Role role = new Role
            {
                Name = request.Name
            };

            await _roleRepository.CreateAsync(role);

            return TypedResults.Created($"/roles/{role.Id}", role);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}
