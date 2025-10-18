using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.UserUseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class UserUseCaseAggregator : IUserUseCaseAggregator
{
    private readonly CreateUserUseCase _createUser;

    public UserUseCaseAggregator(CreateUserUseCase createUser)
    {
        _createUser = createUser;
    }

    public async Task<IResult> CreateUser(CreateUserDTO request)
    {
        return await _createUser.Execute(request);
    }
}
