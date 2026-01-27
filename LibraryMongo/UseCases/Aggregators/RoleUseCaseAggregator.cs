using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.RoleUseCases;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class RoleUseCaseAggregator : IRoleUseCaseAggregator
{
    private readonly CreateRoleUseCase _createRole;
    private readonly GetAllRoleUseCase _getAllRole;
    private readonly UpdateRoleUseCase _updateRole;
    private readonly DeleteRoleUseCase _deleteRole;
    private readonly GetByIdRoleUseCase _getByIdRole;
    private readonly UseCaseDispatcher _useCaseDispatcher;

    public RoleUseCaseAggregator(CreateRoleUseCase createRole, GetAllRoleUseCase getAllRole, UpdateRoleUseCase updateRole, DeleteRoleUseCase deleteRole, GetByIdRoleUseCase getByIdRole, UseCaseDispatcher useCaseDispatcher)
    {
        _createRole = createRole;
        _getAllRole = getAllRole;
        _updateRole = updateRole;
        _deleteRole = deleteRole;
        _getByIdRole = getByIdRole;
        _useCaseDispatcher = useCaseDispatcher;
    }

    public async Task<IResult> CreateRole(CreateRoleDTO request)
    {
        return await _useCaseDispatcher.Dispatch(_createRole, request);
    }
    public async Task<IResult> UpdateRole(UpdateRoleDTO request)
    {
        return await _useCaseDispatcher.Dispatch(_updateRole,   request);
    }

    public async Task<IResult> DeleteRole(string id)
    {
        return await _useCaseDispatcher.Dispatch(_deleteRole,id);
    }
    public async Task<IResult> GetAllRole()
    {
        return await _useCaseDispatcher.Dispatch(_getAllRole, Unit.Value);
    }

    public async Task<IResult> GetByIdRole(string id)
    {
        return await _useCaseDispatcher.Dispatch(_getByIdRole, id);
    }
}
