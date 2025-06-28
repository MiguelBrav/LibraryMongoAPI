using LibraryMongo.Models.DTOs;

namespace LibraryMongo.UseCases.Aggregators.Interfaces;

public interface IRoleUseCaseAggregator
{  
    public Task<IResult> CreateRole(CreateRoleDTO request);
    public Task<IResult> UpdateRole(UpdateRoleDTO request);
    public Task<IResult> DeleteRole(string id);
    public Task<IResult> GetAllRole();
}
