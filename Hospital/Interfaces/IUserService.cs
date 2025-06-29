namespace Hospital.Interfaces;

public interface IUserService
{
    public void MakeReservation(int patientId);
    public void ShowMyReservations();
    public void CancelReservation();
    public void ViewMedicalHistory();
}