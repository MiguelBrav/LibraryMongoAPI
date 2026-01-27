using LibraryMongo.Models.DTOs;
using LibraryMongo.UseCases.Aggregators.Interfaces;
using LibraryMongo.UseCases.UserUseCases;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.Aggregators;

public class UserUseCaseAggregator : IUserUseCaseAggregator
{
    private readonly CreateUserUseCase _createUser;
    private readonly LoginUserUseCase _loginUser;
    private readonly DeleteUserUseCase _deleteUser;
    private readonly LogoutUserUseCase _logoutUser;
    private readonly SetBannedUserUseCase _setBannedUser;
    private readonly GetAllUserUseCase _getAllUserUser;

    private readonly UseCaseDispatcher _useCaseDispatcher;

    public UserUseCaseAggregator(CreateUserUseCase createUser, DeleteUserUseCase deleteUser, LoginUserUseCase loginUser, LogoutUserUseCase logoutUser, SetBannedUserUseCase setBannedUser, GetAllUserUseCase getAllUserUser, UseCaseDispatcher useCaseDispatcher)
    {
        _createUser = createUser;
        _deleteUser = deleteUser;
        _loginUser = loginUser;
        _logoutUser = logoutUser;
        _setBannedUser = setBannedUser;
        _getAllUserUser = getAllUserUser;
        _useCaseDispatcher = useCaseDispatcher;
    }

    public async Task<IResult> CreateUser(CreateUserDTO request)
    {
        return await _useCaseDispatcher.Dispatch(_createUser,request);
    }
    public async Task<IResult> LoginUser(LoginUserDTO request)
    {
        return await _useCaseDispatcher.Dispatch(_loginUser, request);
    }

    public async Task<IResult> DeleteUser(string id)
    {
        return await _useCaseDispatcher.Dispatch(_deleteUser, id);
    }

    public async Task<IResult> LogoutUser()
    {
        return await _useCaseDispatcher.Dispatch(_logoutUser, Unit.Value);
    }
    public async Task<IResult> SetBannedUser(string id)
    {
        return await _useCaseDispatcher.Dispatch(_setBannedUser, id);
    }

    public async Task<IResult> GetAllUser()
    {
        return await _useCaseDispatcher.Dispatch(_getAllUserUser, Unit.Value);
    }
}
