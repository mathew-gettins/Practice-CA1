namespace Part_2
{
    internal class Program
    {
        static string[] names = new string[10];
        static double[] wages = new double[10];

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Menu();
        }

        static void GrossPay()
        {
            int choice;
           
            {
                for (int i = 0; i < names.Length; i++)
                {
                    Console.Write("\nEnter Name         : ");
                    names[i] = Console.ReadLine();

                    Console.Write("Status (W/H)       : ");
                    string status = Console.ReadLine();

                    Console.Write("Enter hours        : ");
                    int hours = int.Parse(Console.ReadLine());

                    Console.Write("Enter years        : ");
                    int years = int.Parse(Console.ReadLine());

                    wages[i] = Wages(status, hours, years);

                    Console.WriteLine($"\n{names[i]} you worked {hours} hours and your wages are €{wages[i]}");
                    Console.WriteLine("");

                    Console.WriteLine("Do you want to continue? (1. Yes, 2. No)");
                    choice = int.Parse(Console.ReadLine());

                    if (choice != 1)
                    {
                        break;
                    }
                    else
                    {
                        Menu();
                    }
                }
            } 
        }

        static void Menu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("                    1.      Calculate Gross Pay       ");
            Console.WriteLine("                    2.      Print Session Statistics    ");
            Console.WriteLine("                    3.      Exit                      ");
            Console.Write("Enter Choice:");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
                GrossPay();
            else if (choice == 2)
                PrintSessionStatistics();
            else if (choice == 3)
            {
                Console.WriteLine("You have exited the menu");
                return;
            }
            else
                Console.WriteLine("Invalid choice. Please enter a valid choice.");
        }

        static double Wages(string status, int hours, int years)
        {
            int overtime = 15;
            double threeYearService = 0.10;
            int weekPay = 500;
            double wageAmount = 0;

            status = status.ToUpper();

            if (status == "W")
            {
                if (hours > 40)
                {
                    wageAmount = (hours - 40) * overtime + weekPay;
                }
                else if (hours == 40)
                {
                    wageAmount = weekPay;
                }
            }
            else
            {
                wageAmount = hours * 12;
            }

            if (years > 3)
            {
                wageAmount = wageAmount + (wageAmount * threeYearService);
            }

            return wageAmount;
        }

        static void PrintSessionStatistics()

        {
            Console.WriteLine("Pay Report");
            Console.WriteLine("Name                Amount Paid");
            for (int i = 0; i < wages.Length; i++)
            {
                Console.WriteLine($"{names[i]}        {wages[i]}");
            }
            
        }
    }  
}
