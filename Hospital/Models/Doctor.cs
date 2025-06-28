namespace Hospital.Models;

public class Doctor:User
{
    public int Id { get; set; }
    public Department Department { get; set; }
    public int DepartmentId { get; set; }
    public List<Reservation> ReservationTime { get; set; }
}