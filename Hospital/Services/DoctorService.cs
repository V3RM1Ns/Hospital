public class DoctorService :User, IDoctorService
{
   
    public void AddReservation()
    {
        Console.Write("Enter available reservation date (yyyy-MM-dd HH:mm): ");
        DateTime reservationDate;
        while (!DateTime.TryParse(Console.ReadLine(), out reservationDate))
        {
            Console.Write("Invalid date. Please enter again (yyyy-MM-dd HH:mm): ");
        }
        
        bool alreadyExists = _context.Reservations
            .Any(r => r.DoctorId == _doctorId && r.Date == reservationDate);

        if (alreadyExists)
        {
            Console.WriteLine("You have already added this time slot.");
            return;
        }

        var reservation = new Reservation
        {
            DoctorId = _doctorId,
            Date = reservationDate,
            IsReserved = false
        };

        _context.Reservations.Add(reservation);
        _context.SaveChanges();

        Console.WriteLine("Time slot added successfully.");
    }

    public void ShowReservations()
    {
        var reservations = _context.Reservations.ToList();
        int i = 1;
        foreach (var reservation in reservations)
        {
            Console.WriteLine($"{i}- {reservation}");
        }
    }
    
    
    private readonly AppDbContext _context;
    private readonly int _doctorId;
    public DoctorService(int doctorId)
    {
        _context = new AppDbContext(); 
        _doctorId = doctorId;
    }

}