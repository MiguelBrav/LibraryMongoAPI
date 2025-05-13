using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.RoleUseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class RoleUseCaseAggregator : IRoleUseCaseAggregator
{
    private readonly CreateRoleUseCase _createRole;

    public RoleUseCaseAggregator(CreateRoleUseCase createRole)
    {
        _createRole = createRole;
    }

    public async Task<IResult> CreateRole(CreateRoleDTO request)
    {
        return await _createRole.Execute(request);
    }
}
