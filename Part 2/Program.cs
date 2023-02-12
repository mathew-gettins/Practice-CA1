namespace Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string status = "";
            int years = 0;
            int hours = 0;

            string[] names = new string[10];
            double[] wages = new double[10];

            for (int i = 0; i < names.Length; i++)
            {
                Console.Write("Enter Name         : ");
                names[i] = Console.ReadLine();

                Console.Write("Status (W/H)       : ");
                status = Console.ReadLine();

                Console.Write("Enter hours        : ");
                hours = int.Parse(Console.ReadLine());

                Console.Write("Enter years        : ");
                years = int.Parse(Console.ReadLine());

                wages[i] = Wages(status, hours, years);

                Console.WriteLine($"{names[i]} you worked {hours} hours and your wages are €{wages[i]}");
            }
        }

        static double Wages(string status, int hours, int years)
        {
            int overtime = 15;
            double threeYearService = 0.10;
            int weekPay = 500;
            double wageAmount = 0;

            if (status == "W")
            {
                if (hours > 40)
                {
                    wageAmount = (hours - 40) * overtime + weekPay;
                }
                else
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
                wageAmount = wageAmount * (1 + threeYearService);
            }

            return wageAmount;
        }
    }
}
