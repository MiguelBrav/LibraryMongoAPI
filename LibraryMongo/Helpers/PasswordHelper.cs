using System.Security.Cryptography;

namespace LibraryMongo.Helpers;

public static class PasswordHelper
{
    private const int SaltSize = 16; 
    private const int HashSize = 32;
    private const int Iterations = 100_000; 

    public static string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            HashAlgorithmName.SHA256,
            HashSize);

        return Convert.ToBase64String(salt) + "." + Convert.ToBase64String(hash);
    }

    public static bool VerifyPassword(string storedPassword, string enteredPassword)
    {
        var parts = storedPassword.Split('.');
        if (parts.Length != 2)
            return false;

        byte[] salt = Convert.FromBase64String(parts[0]);
        byte[] storedHash = Convert.FromBase64String(parts[1]);

        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            enteredPassword,
            salt,
            Iterations,
            HashAlgorithmName.SHA256,
            HashSize);

        return CryptographicOperations.FixedTimeEquals(storedHash, hash);
    }
}
