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
            .Any(r => r.UserId == _UserId && r.Date == reservationDate);

        if (alreadyExists)
        {
            Console.WriteLine("You have already added this time slot.");
            return;
        }

        var reservation = new Reservation
        {
            UserId = _UserId,
            Date = reservationDate,
            IsReserved = false
        };

        _context.Reservations.Add(reservation);
        _context.SaveChanges();
        Console.Clear();
        Console.WriteLine("Time slot added successfully.");
        Thread.Sleep(2000);
    }

    public void ShowReservations()
    {
        var reservations = _context.Reservations
            .Where(r => r.UserId == _UserId)
            .ToList();

        if (!reservations.Any())
        {
            Console.WriteLine("No reservations found.");
            return;
        }

        int i = 1;
        foreach (var reservation in reservations)
        {
            Console.WriteLine($"{i++} - {reservation}");
        }
    }

    
    
    private readonly AppDbContext _context;
    private readonly int _UserId;
    public DoctorService(int UserId)
    {
        _context = new AppDbContext(); 
        _UserId = UserId;
    }

}