using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.RoleUseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class RoleUseCaseAggregator : IRoleUseCaseAggregator
{
    private readonly CreateRoleUseCase _createRole;
    private readonly GetAllRoleUseCase _getAllRole;
    private readonly UpdateRoleUseCase _updateRole;
    private readonly DeleteRoleUseCase _deleteRole;
    private readonly GetByIdRoleUseCase _getByIdRole;

    public RoleUseCaseAggregator(CreateRoleUseCase createRole, GetAllRoleUseCase getAllRole, UpdateRoleUseCase updateRole, DeleteRoleUseCase deleteRole, GetByIdRoleUseCase getByIdRole)
    {
        _createRole = createRole;
        _getAllRole = getAllRole;
        _updateRole = updateRole;
        _deleteRole = deleteRole;
        _getByIdRole = getByIdRole;
    }

    public async Task<IResult> CreateRole(CreateRoleDTO request)
    {
        return await _createRole.Execute(request);
    }
    public async Task<IResult> UpdateRole(UpdateRoleDTO request)
    {
        return await _updateRole.Execute(request);
    }

    public async Task<IResult> DeleteRole(string id)
    {
        return await _deleteRole.Execute(id);
    }
    public async Task<IResult> GetAllRole()
    {
        return await _getAllRole.Execute(Unit.Value);
    }

    public async Task<IResult> GetByIdRole(string id)
    {
        return await _getByIdRole.Execute(id);
    }
}
