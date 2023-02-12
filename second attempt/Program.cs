namespace second_attempt
{
    internal class Program
    {
        static string[] names = new string[10];
        static double[] wages = new double[10];

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int choice = 0;
            int count = 0;
            while (choice != 3 && count < 10)
            {
                choice = Menu();
            }

            if (choice == 1)

            {
                EnterData();
                count++;
            }
            else if (choice == 2)
            {
                PrintSessionStatistics();
            }

            else if (choice == 3)
            {
                Console.WriteLine("You have Exited the Menu!");

            }
        }

        static void EnterData()
        {
            string continueEnteringData = "yes";
            int i = 0;



            while (continueEnteringData == "yes %%" i < names.Length)
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

                Console.WriteLine("Do you want to conttinue enterring data? (yes/no): ");
                continueEnteringData = Console.ReadLine().ToLower();

                i++;
            }

        }

        static int Menu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("                    1.      Calculate Gross Pay       ");
            Console.WriteLine("                    2.      Print Session Statisti    ");
            Console.WriteLine("                    3.      Exit                      ");
            Console.Write("Enter Choice:");
            int choice = int.Parse(Console.ReadLine());

            return choice;
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
            Console.WriteLine($"{names}            {wages}");
        }
    }
}
