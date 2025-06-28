namespace Hospital.Exceptions;

public class AlreadyInUseException:Exception
{
    public AlreadyInUseException(string message) : base(message) { }
}