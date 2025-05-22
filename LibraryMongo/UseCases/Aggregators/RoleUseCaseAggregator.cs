using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.RoleUseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class RoleUseCaseAggregator : IRoleUseCaseAggregator
{
    private readonly CreateRoleUseCase _createRole;
    private readonly GetAllRoleUseCase _getAllRole;

    public RoleUseCaseAggregator(CreateRoleUseCase createRole, GetAllRoleUseCase getAllRole)
    {
        _createRole = createRole;
        _getAllRole = getAllRole;
    }

    public async Task<IResult> CreateRole(CreateRoleDTO request)
    {
        return await _createRole.Execute(request);
    }

    public async Task<IResult> GetAllRole()
    {
        return await _getAllRole.Execute(Unit.Value);
    }
}
