using System.Diagnostics.Metrics;

namespace Part_2
{
    internal class Program
    {
        static string[] names = new string[10]; // array to store employee names
        static double[] wages = new double[10]; // array to store employee wages

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // set the output encoding to UTF8
            Menu(); // call the menu method
        }

        // method to calculate and display employee gross pay
        static void GrossPay()
        {
            int counter = 0; // counter to keep track of the number of employees
            while (true)
            {
                Console.Write("\nEnter Name         : ");
                names[counter] = Console.ReadLine(); // read and store the employee name

                Console.Write("Status (W/H)       : ");
                string status = Console.ReadLine(); // read and store the employee status (W or H)

                Console.Write("Enter hours        : ");
                int hours = int.Parse(Console.ReadLine()); // read and store the number of hours worked

                Console.Write("Enter years        : ");
                int years = int.Parse(Console.ReadLine()); // read and store the number of years worked

                wages[counter] = Wages(status, hours, years); // calculate the gross pay

                Console.WriteLine($"\n{names[counter]} you worked {hours} hours and your wages are €{wages[counter]}");
                Console.WriteLine();

                Console.Write("Do you want to continue? (1. Yes, 2. No)");
                int choice = int.Parse(Console.ReadLine());

                if (choice != 1) // if the user chooses not to continue, break out of the loop
                {
                    break;
                }

                counter++; // increment the counter
            }

            Menu(); // return to the menu
        }

        // method to display the menu
        static void Menu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("                    1.      Calculate Gross Pay       ");
            Console.WriteLine("                    2.      Print Session Statistics    ");
            Console.WriteLine("                    3.      Exit                      ");
            Console.Write("Enter Choice:");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    GrossPay(); // if the user chooses 1, call the GrossPay method
                    break;
                case 2:
                    PrintSessionStatistics(); // if the user chooses 2, call the PrintSessionStatistics method
                    break;
                case 3:
                    Console.WriteLine("You have exited the menu");
                    return; // if the user chooses 3, end the program
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid choice.");
                    break;
            }
        }

        static double Wages(string status, int hours, int years)
        {
            // Define overtime rate, three year service bonus, and weekly pay
            var overtime = 15;
            var threeYearService = 0.10;
            var weekPay = 500;
            double wageAmount = 0;

            // Convert status to uppercase
            status = status.ToUpper();

            // Calculate wage amount based on employee status
            if (status == "W")
            {
               
                if (hours > 40)         // If hours worked is greater than 40, calculate wage amount with overtime
                {
                    wageAmount = (hours - 40) * overtime + weekPay;
                }
                
                else if (hours == 40)    // If hours worked is equal to 40, wage amount is just the weekly pay
                {
                    wageAmount = weekPay;
                }
            }

            else         // if status is "H"
            {
                wageAmount = hours * 12;          // If employee status is not "W", wage amount is hours worked multiplied by hourly rate
            }

            
            if (years > 3)         // Add three year service bonus if years worked is greater than 3
            {
                wageAmount = wageAmount + (wageAmount * threeYearService);
            }

            // Return final wage amount
            return wageAmount;
        }

        static void PrintSessionStatistics()
        {
            Console.WriteLine("Pay Report");
            Console.WriteLine("Name                Amount Paid");
            for (int i = 0; i < wages.Length; i++)
            {
               
                if (wages[i] > 0)     // Only print information for employees who have been paid
                {
                    Console.WriteLine($"{names[i]}        {wages[i]}");
                }
            }
        }
    }
}
