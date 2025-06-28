using Hospital.Services;
using Hospital.Models;

class Program
{
    static void Main(string[] args)
    {
        
        AuthService authService = new AuthService();
        Admin Admin = new Admin();
        User User = new User();
        Doctor Doctor = new Doctor();
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1 - Register");
            Console.WriteLine("2 - Login");
            Console.WriteLine("3 - Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    authService.Register();
                    break;
                case "2":
                    User user = authService.Login();
                    if (user != null)
                    {
                        if (user.Role == Role.Admin)
                        {
                            Console.Clear();
                            Console.WriteLine("Admin Logged in.");
                            Thread.Sleep(2000);
                            ShowAdminPanel(Admin);
                        }

                        if (user.Role == Role.User)
                        {
                            Console.Clear();
                            Console.WriteLine("Patient Logged in.");
                            Thread.Sleep(2000);
                            ShowUserPanel(User);
                        }

                        if (user.Role == Role.Doctor)
                        {
                            Console.Clear();
                            Console.WriteLine("Doctor Logged in.");
                            Thread.Sleep(2000);
                            ShowDoctorPanel(Doctor);
                        }
                    }

                    break;
                case "3":
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }

    static void ShowAdminPanel(Admin Admin)
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("\n=== Admin Panel ===");
            Console.WriteLine("1. Add Department");
            Console.WriteLine("2. Add Doctor");
            Console.WriteLine("3. Logout");
            Console.Write("Select an option: ");

            string AdminChoice = Console.ReadLine();

            try
            {
                switch (AdminChoice)
                {
                    case "1":
                        Admin.AddDepartment();
                        Console.WriteLine("Department added successfully.");
                        break;

                    case "2":
                        Admin.AddDoctor();
                        break;

                    case "3":
                        back = true;
                        Console.WriteLine("Logging out from Admin panel...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static void ShowUserPanel(User User)
    {

    }

    static void ShowDoctorPanel(Doctor Doctor)
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("\n=== Doctor Panel ===");
            Console.WriteLine("1. Add Reservation Time");
            Console.WriteLine("2. Show Reservations");
            Console.WriteLine("3. Logout");
            Console.Write("Select an option: ");

            string DoctorChoice = Console.ReadLine();

            try
            {
                switch (DoctorChoice)
                {
                    case "1":
                        //DoctorService.AddReservation();
                        break;

                    case "2":
                       // DoctorService.ShowReservations();
                        break;

                    case "3":

                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

