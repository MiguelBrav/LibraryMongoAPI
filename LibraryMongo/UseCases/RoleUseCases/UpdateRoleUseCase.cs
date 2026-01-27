using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Infrastructure.Repositories;
using LibraryMongo.Models.DTOs;
using LibraryMongo.Models.Entities;
using MongoDB.Bson;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.RoleUseCases;

public class UpdateRoleUseCase : UseCaseBase<UpdateRoleDTO, IResult>
{
    private readonly IRoleRepository _roleRepository;

    public UpdateRoleUseCase(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public override async Task<IResult> Execute(UpdateRoleDTO request)
    {
        try
        {
            if (request.Name == null || !request.Name.Any())
            {
                return TypedResults.BadRequest("Name dictionary is required and cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.Id))
            {
                return TypedResults.BadRequest("Id is required and cannot be empty.");
            }

            Role _existingRole = await _roleRepository.GetById(request.Id);

            if (_existingRole is null)
            {
                return TypedResults.NotFound();
            }

            Role role = new Role
            {
                Name = request.Name,
                Id = ObjectId.Parse(request.Id)
            };

            bool isUpdated = await _roleRepository.UpdateAsync(role);

            if (!isUpdated)
            {
                return TypedResults.Ok("No changes were made to the role.");
            }

            return TypedResults.Ok(role);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}
