using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Infrastructure.Repositories;
using LibraryMongo.Models.DTOs;
using LibraryMongo.Models.Entities;
using MongoDB.Bson;
using System.Data;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.RoleUseCases;

public class DeleteRoleUseCase : UseCaseBase<string, IResult>
{
    private readonly IRoleRepository _roleRepository;

    public DeleteRoleUseCase(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public override async Task<IResult> Execute(string id)
    {
        try
        {
            if (string.IsNullOrEmpty(id))
            {
                return TypedResults.BadRequest("Id is required and cannot be empty.");
            }

            Role _existingRole = await _roleRepository.GetById(id);

            if (_existingRole is null)
            {
                return TypedResults.NotFound();
            }

            bool isDeleted = await _roleRepository.DeleteAsync(id);

            if (!isDeleted)
            {
                return TypedResults.Problem("Failed to delete the role.");
            }

            return TypedResults.Ok("Role deleted successfully.");
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}
