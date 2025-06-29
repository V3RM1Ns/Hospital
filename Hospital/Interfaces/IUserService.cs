namespace Hospital.Interfaces;

public interface IUserService
{
    public void MakeReservation();
    public void ShowMyReservations();
    public void CancelReservation();
    public void ViewMedicalHistory();
}