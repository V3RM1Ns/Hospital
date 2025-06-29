
class Program
{
    static void Main(string[] args)
    {
        AuthService authService = new AuthService();
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
                        bool backToMain = false;
                        while (!backToMain)
                        {
                            Console.Clear();
                            Console.WriteLine($"\nWelcome, {user.Name} ({user.Role})");
                            Console.WriteLine("1. Admin Panel");
                            Console.WriteLine("2. Doctor Panel");
                            Console.WriteLine("3. User Panel");
                            Console.WriteLine("4. Logout");
                            Console.Write("Choose a panel: ");
                            string panelChoice = Console.ReadLine();

                            switch (panelChoice)
                            {
                                case "1":
                                    if (user.Role == Role.Admin)
                                        ShowAdminPanel(user);
                                    else
                                        Console.WriteLine("❌ You are not authorized to access Admin Panel.");
                                    break;

                                case "2":
                                    if (user.Role == Role.Doctor)
                                        ShowDoctorPanel(user);
                                    else
                                        Console.WriteLine("❌ You are not authorized to access Doctor Panel.");
                                    break;

                                case "3":
                                    if (user.Role == Role.User)
                                        ShowUserPanel(user);
                                    else
                                        Console.WriteLine("❌ You are not authorized to access User Panel.");
                                    break;

                                case "4":
                                    backToMain = true;
                                    break;

                                default:
                                    Console.WriteLine("Invalid option.");
                                    break;
                            }

                            Thread.Sleep(2000);
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
    static void ShowAdminPanel(User user)
    {
        var adminService = new AdminService();
        bool back = false;

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=== Admin Panel ===");
            Console.WriteLine("1. Add Department");
            Console.WriteLine("2. Add Doctor");
            Console.WriteLine("3. Exit to Main Menu");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    adminService.AddDepartment();
                    break;
                case "2":
                    adminService.AddDoctor();
                    break;
                case "3":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            if (!back)
                Thread.Sleep(2000);
        }
    }

    static void ShowDoctorPanel(User user)
    {
        var doctorService = new DoctorService(user.Id);
        bool back = false;

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=== Doctor Panel ===");
            Console.WriteLine("1. Add Reservation");
            Console.WriteLine("2. Show Reservations");
            Console.WriteLine("3. Exit to Main Menu");

            Console.Write("Select an option: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    doctorService.AddReservation();
                    break;
                case "2":
                    doctorService.ShowReservations();
                    break;
                case "3":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            if (!back)
                Thread.Sleep(2000);
        }
    }
    
    static void ShowUserPanel(User user)
    {
        
    }

}

