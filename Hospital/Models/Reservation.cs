namespace Hospital.Models;

public class Reservation
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int DoctorId { get; set; }
    public DateTime Date { get; set; }
    public bool IsReserved { get; set; } = false;

    public override string ToString()
    {
        string status = IsReserved ? "✅Reserved" : "❌Not Reserved";
        return $"{Date:yyyy-MM-dd HH:mm}  {status}";
    }

}