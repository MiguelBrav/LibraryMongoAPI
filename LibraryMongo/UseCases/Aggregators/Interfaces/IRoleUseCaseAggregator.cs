using LibraryMongo.Models.DTOs;

namespace LibraryMongo.UseCases.Aggregators.Interfaces;

public interface IRoleUseCaseAggregator
{    public Task<IResult> CreateRole(CreateRoleDTO request);
}
