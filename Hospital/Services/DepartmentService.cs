using Hospital.Contexts;
using Hospital.Interfaces;
using Hospital.Models;

namespace Hospital.Services;

public class DepartmentService : IDepartmentService
{
    private readonly AppDbContext _context;

    public DepartmentService()
    {
        _context = new AppDbContext();
    }

    public void GetAllDepartments()
    {
        var departments = _context.Departments.ToList();

        if (departments.Count == 0)
        {
            Console.WriteLine("No departments found.");
            return;
        }

        Console.WriteLine("=== Department Names ===");
        int i = 1;
        foreach (var dept in departments)
        {
            Console.WriteLine($"{i}-{dept.Name}");
            i++;
        }
    }
}