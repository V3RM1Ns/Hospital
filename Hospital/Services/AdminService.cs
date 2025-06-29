namespace Hospital.Services;
public class AdminService:User,IAdminService
{
    
    public void AddDoctor()
    {
        _departmentService.GetAllDepartments();
        
        Console.Write("Enter Department Name: ");
        string deptName=Console.ReadLine();
        
        Department? department = _appDbContext.Departments.FirstOrDefault(x => x.Name == deptName);

        if (department == null)
        {
            Console.WriteLine("Department not found!");
            Thread.Sleep(2000);
            return;
        }
        
        Console.Write("Enter Doctor Name: ");
        string doctorName = Console.ReadLine();

        Console.Write("Enter Doctor Email: ");
        string doctorEmail = Console.ReadLine();
        if (_appDbContext.Doctors.Any(d =>d.Email == doctorEmail))
            throw new AlreadyInUseException("Email already exists!");

        Console.Write("Enter Doctor Password: ");
        string doctorPassword = Console.ReadLine();
        string hashedPassword = PasswordHelper.HashPassword(doctorPassword);
        Doctor newDoctor = new Doctor
        {
            Name = doctorName,
            Email = doctorEmail, 
            Password = hashedPassword,
            DepartmentId = department.Id,
            Department = department, 
            Role= Role.Doctor
        };

        _appDbContext.Doctors.Add(newDoctor);
        _appDbContext.SaveChanges();
        Console.Clear();
        Console.WriteLine("Doctor added successfully.");
        Thread.Sleep(2000);
    }

    public void AddDepartment()
    {
        Console.Write("Enter department name: ");
        string name = Console.ReadLine();
        if (name == null)
        {
            throw new EmptyNameException("Department name cannot be empty");
        }
        if(_appDbContext.Departments.FirstOrDefault(d => d.Name.ToUpper() == name.ToUpper()) != null)
            throw new AlreadyInUseException("Department already exists");

        Department newDepartment = new Department
        {
            Name = name
        };
        _appDbContext.Departments.Add(newDepartment);
        _appDbContext.SaveChanges();
    }
    
    
    
    
    
    
    private readonly AppDbContext _appDbContext;
    private readonly DepartmentService _departmentService;

    public AdminService()
    {
        _appDbContext = new AppDbContext();
        _departmentService = new DepartmentService();
    }
}