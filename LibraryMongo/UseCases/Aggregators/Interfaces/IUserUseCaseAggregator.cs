using LibraryMongo.Models.DTOs;

namespace LibraryMongo.UseCases.Aggregators.Interfaces;

public interface IUserUseCaseAggregator
{  
    public Task<IResult> CreateUser(CreateUserDTO request);

}
