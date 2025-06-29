namespace Hospital.Services;

public class UserService:IUserService
{
    public void MakeReservation(int patientId)
{
    _departmentService.GetAllDepartments();
    Console.Write("Enter Department Name: ");
    string deptName = Console.ReadLine();

    Department? department = _appDbContext.Departments.FirstOrDefault(x => x.Name == deptName);
    if (department == null)
    {
        Console.WriteLine("❌ Department not found!");
        Thread.Sleep(2000);
        return;
    }

    var doctors = _appDbContext.Doctors
        .Where(d => d.DepartmentId == department.Id)
        .ToList();

    if (doctors.Count == 0)
    {
        Console.WriteLine("❌ No doctors in this department.");
        return;
    }

    Console.WriteLine($"\nDoctors in {department.Name}:");
    for (int i = 0; i < doctors.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {doctors[i].Name}");
    }

    Console.Write("Select doctor number: ");
    if (!int.TryParse(Console.ReadLine(), out int docIndex) || docIndex < 1 || docIndex > doctors.Count)
    {
        Console.WriteLine("❌ Invalid doctor selection.");
        return;
    }

    var selectedDoctor = doctors[docIndex - 1];

    // Həkimin mövcud boş vaxtlarını göstər
    var availableSlots = _appDbContext.Reservations
        .Where(r => r.UserId == selectedDoctor.Id && r.IsReserved == false)
        .ToList();

    if (availableSlots.Count == 0)
    {
        Console.WriteLine("❌ No available slots for this doctor.");
        return;
    }

    Console.WriteLine("\nAvailable time slots:");
    for (int i = 0; i < availableSlots.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {availableSlots[i].Date}");
    }

    Console.Write("Select a slot number: ");
    if (!int.TryParse(Console.ReadLine(), out int slotIndex) || slotIndex < 1 || slotIndex > availableSlots.Count)
    {
        Console.WriteLine("❌ Invalid slot selection.");
        return;
    }

    var selectedSlot = availableSlots[slotIndex - 1];

    // Rezervasiyanı təsdiqlə
    selectedSlot.IsReserved = true;
    selectedSlot.UserId = patientId;
    _appDbContext.SaveChanges();

    Console.WriteLine("✅ Reservation successful!");
    Thread.Sleep(2000);
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