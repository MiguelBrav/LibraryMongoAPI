using LibraryMongo.Domain.Interfaces;
using LibraryMongo.Helpers;
using LibraryMongo.Models.DTOs;
using LibraryMongo.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.UserUseCases;

public class LoginUserUseCase : UseCaseBase<LoginUserDTO, IResult>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoginUserUseCase(IRoleRepository roleRepository, IUserRepository userRepository, IConfiguration config, IHttpContextAccessor httpContextAccessor)
    {
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public override async Task<IResult> Execute(LoginUserDTO request)
    {
        try
        {
            User user = await _userRepository.GetByUsernameAsync(request.Username);

            if (user == null || !PasswordHelper.VerifyPassword(user.Password, request.Password))
                return Results.Unauthorized();

            if (user.IsBanned)
                return Results.Forbid();

            string _userRoleId = user.RolId.ToString() ?? string.Empty;    

            Role userRole = await _roleRepository.GetById(_userRoleId);

            string roleNameEn = userRole.Name.TryGetValue("en", out var enValue)  ? enValue : "Unknown";

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, roleNameEn)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            HttpContext http = _httpContextAccessor.HttpContext!;
            await http.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return Results.Ok(new { message = "Login successful" });
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}

