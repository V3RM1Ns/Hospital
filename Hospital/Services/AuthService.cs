using Hospital.Contexts;
using Hospital.Models;

namespace Hospital.Services;

public class AuthService
{
    private readonly AppDbContext _context;

    public AuthService()
    {
        _context = new AppDbContext();
    }

    public void Register()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        if (username == "") throw new EmptyNameException("Username is empty");

        if (_context.Users.Any(u => u.Name == username))
        {
            Console.WriteLine("Username already exists.");
            return;
        }

        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        if (password=="") throw new EmptyNameException("Password is empty");
        string hashedPassword = PasswordHelper.HashPassword(password);
        
        
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();
        if (email == "") throw new EmptyNameException("Email is empty");

        var user = new User
        {
            Name = username,
            Password = hashedPassword,
            Email = email,
            Role=Role.User
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        Console.WriteLine("Registration successful.");
    }

    public User Login()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        string hashedPassword = PasswordHelper.HashPassword(password);

        var user = _context.Users.FirstOrDefault(u => u.Name == username && u.Password == hashedPassword) ;

        if (user != null)
        {
            return user;
        }
        else
        {
            Console.WriteLine("Invalid username or password.");
            Thread.Sleep(2000);
            return null;
        }
    }
}