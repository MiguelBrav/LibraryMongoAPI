using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.UserUseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class UserUseCaseAggregator : IUserUseCaseAggregator
{
    private readonly CreateUserUseCase _createUser;
    private readonly DeleteUserUseCase _deleteUser;

    public UserUseCaseAggregator(CreateUserUseCase createUser, DeleteUserUseCase deleteUser)
    {
        _createUser = createUser;
        _deleteUser = deleteUser;
    }

    public async Task<IResult> CreateUser(CreateUserDTO request)
    {
        return await _createUser.Execute(request);
    }

    public async Task<IResult> DeleteUser(string id)
    {
        return await _deleteUser.Execute(id);
    }
}
