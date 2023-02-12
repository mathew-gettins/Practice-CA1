namespace Third_attempt
{
    class Program
    {
        static string[] names = new string[10];
        static double[] wages = new double[10];

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;   // set console output encoding
            int count = 0;   // initialize count
            int choice;   // initialize choice

            do
            {
                Console.WriteLine("Menu:");   // display menu
                Console.WriteLine("1. Calculate Gross Pay");
                Console.WriteLine("2. Print Session Statistics");
                Console.WriteLine("3. Exit");
                Console.Write("Enter Choice: ");

                choice = int.Parse(Console.ReadLine());   // get user choice

                switch (choice)   // switch on user choice
                {
                    case 1:
                        Console.Write("Enter Name: ");
                        names[count] = Console.ReadLine();   // get name
                        Console.Write("Status (W/H): ");
                        string status = Console.ReadLine();   // get status
                        Console.Write("Enter Hours: ");
                        int hours = int.Parse(Console.ReadLine());   // get hours
                        Console.Write("Enter Years: ");
                        int years = int.Parse(Console.ReadLine());   // get years

                        wages[count] = Wages(status, hours, years);   // calculate wage amount
                        Console.WriteLine(names[count] + " you worked " + hours + " hours and your wages are €" + wages[count]);   // display wage amount
                        Console.WriteLine();

                        count++;   // increment count
                        break;
                    case 2:
                        PrintSessionStatistics();   // call print session statistics
                        break;
                }
            } while (choice != 3 && count < 10);   // repeat until choice is 3 or count is 10
        }

        static double Wages(string status, int hours, int years)
        {
            var overtime = 15;   // initialize overtime
            var threeYearService = 0.10;   // initialize three year service
            var weekPay = 500;   // initialize weekly pay
            double wageAmount = 0;   // initialize wage amount

            status = status.ToUpper();   // convert status to uppercase

            if (status == "W")   // if status is "W"
            {
                if (hours > 40)   // if hours are greater than 40
                {
                    wageAmount = (hours - 40) * overtime + weekPay;   // calculate wage amount
                }
                else if (hours == 40)   // if hours are equal to 40
                {
                    wageAmount = weekPay;   // set wage amount to weekly pay
                }
            }
            else   // if status is "H"
            {
                wageAmount = hours * 12;   // calculate wage amount
            }

            if (years > 3)   // if years are greater than 3
            {
                wageAmount = wageAmount + (wageAmount * threeYearService);   // add 3-year service bonus to wage amount
            }

            return wageAmount;   // return wage amount
        } 

        static void PrintSessionStatistics()
        {
            Console.WriteLine("Pay Report");
            Console.WriteLine("Name\t\tAmount Paid");

            double totalWages = 0; // Keeps a total of all the wages
            int weeklyPaid = 0; // Keeps track of employees paid weekly
            int totalEmployees = 0; // Total number of employees
            int employeesMoreThan300 = 0; // Keeps track of employees paid over €300

            for (int i = 0; i < wages.Length; i++)
            {
                if (wages[i] > 0)
                {
                    Console.WriteLine(names[i] + "\t\t" + wages[i]); // Print the name and wage of current employee
                    totalWages += wages[i]; // Add current employee's wage to total
                    totalEmployees++; // Increment the number of employees

                    if (wages[i] > 300)
                    {
                        employeesMoreThan300++; // Increment the number of employees paid over €300
                    }

                    if (names[i].ToUpper().Contains("W"))
                    {
                        weeklyPaid++; // Increment the number of employees who are paid weekly
                    }
                }
            }
            Console.WriteLine("\nTotal Employees: " + totalEmployees); // Output the total number of employees
            Console.WriteLine("Weekly Paid: " + weeklyPaid); // Output the number of weekly paid employees
            Console.WriteLine("Employees Paid Over €300: " + employeesMoreThan300); // Output the number of employees paid over €300
            Console.WriteLine("Total Wages: €" + totalWages); // Output the total wages paid
        }

    }
}
