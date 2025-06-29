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

    public void GetAllDoctorsInDepartment()
    {
        Console.Write("Enter Department Name: ");
        string deptName = Console.ReadLine();

        Department? department = _context.Departments.FirstOrDefault(x => x.Name == deptName);

        if (department == null)
        {
            Console.WriteLine("Department not found!");
            Thread.Sleep(2000);
            return;
        }

        var doctors = _context.Doctors
            .Where(d => d.DepartmentId == department.Id)
            .ToList();

        if (doctors.Count == 0)
        {
            Console.WriteLine("No doctors found in this department.");
            return;
        }

        Console.WriteLine($"\nDoctors in {department.Name}:");
        int i = 1;
        foreach (var doctor in doctors)
        {
            Console.WriteLine($"{i}. {doctor.Name}");
            i++;
        }
    }

}