using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using UseCaseCore.UseCases;

namespace LibraryMongo.UseCases.UserUseCases;

public class LogoutUserUseCase : UseCaseBase<Unit, IResult>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LogoutUserUseCase(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override async Task<IResult> Execute(Unit emptyRequest)
    {
        try
        {
            HttpContext http = _httpContextAccessor.HttpContext!;

            await http.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Results.Ok(new { message = "Logout successful" });
        }
        catch (Exception ex)
        {
            return TypedResults.Problem($"An unexpected error occurred: {ex.Message}");
        }
    }
}

