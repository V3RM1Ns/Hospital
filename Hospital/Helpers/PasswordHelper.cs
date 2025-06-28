using System.Security.Cryptography;
using System.Text;

public static class PasswordHelper
{
    public static string HashPassword(string password)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(password);
        byte[] hash = sha256.ComputeHash(bytes);

        // Hash-i oxunaqlı string formatına çevir
        return BitConverter.ToString(hash).Replace("-", "").ToLower();
    }
}