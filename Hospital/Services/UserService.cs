namespace Hospital.Services;

public class UserService:IUserService
{
    public void MakeReservation()
    {
        Console.Write("Enter Department Name: ");
        string deptName = Console.ReadLine();

        Department? department = _appDbContext.Departments.FirstOrDefault(x => x.Name == deptName);

        if (department == null)
        {
            Console.WriteLine("Department not found!");
            Thread.Sleep(2000);
            return;
        }

        var doctors = _appDbContext.Doctors
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

    public void ShowMyReservations()
    {
        throw new NotImplementedException();
    }

    public void CancelReservation()
    {
        throw new NotImplementedException();
    }

    public void ViewMedicalHistory()
    {
        throw new NotImplementedException();
    }
    
    private readonly AppDbContext _appDbContext;
    private readonly DepartmentService _departmentService;

    public UserService()
    {
        _appDbContext = new AppDbContext();
        _departmentService = new DepartmentService();
    }
    
}