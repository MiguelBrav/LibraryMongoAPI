using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.UserUseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class UserUseCaseAggregator : IUserUseCaseAggregator
{
    private readonly CreateUserUseCase _createUser;
    private readonly LoginUserUseCase _loginUser;
    private readonly DeleteUserUseCase _deleteUser;
    private readonly LogoutUserUseCase _logoutUser;
    private readonly SetBannedUserUseCase _setBannedUser;
    public UserUseCaseAggregator(CreateUserUseCase createUser, DeleteUserUseCase deleteUser, LoginUserUseCase loginUser, LogoutUserUseCase logoutUser, SetBannedUserUseCase setBannedUser)
    {
        _createUser = createUser;
        _deleteUser = deleteUser;
        _loginUser = loginUser;
        _logoutUser = logoutUser;
        _setBannedUser = setBannedUser;
    }

    public async Task<IResult> CreateUser(CreateUserDTO request)
    {
        return await _createUser.Execute(request);
    }
    public async Task<IResult> LoginUser(LoginUserDTO request)
    {
        return await _loginUser.Execute(request);
    }

    public async Task<IResult> DeleteUser(string id)
    {
        return await _deleteUser.Execute(id);
    }

    public async Task<IResult> LogoutUser()
    {
        return await _logoutUser.Execute(Unit.Value);
    }
    public async Task<IResult> SetBannedUser(string id)
    {
        return await _setBannedUser.Execute(id);
    }
}
