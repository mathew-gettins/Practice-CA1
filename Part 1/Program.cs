using System.Data;

namespace Part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CalculateTip(26.95, "good"));      // Call the `CalculateTip` method and print the result to the console
        }

        public static int CalculateTip(double amount, string rating)
        {
            rating = rating.ToLower();                          // Convert the rating to lower case for case-insensitivity
                                                          
            switch (rating)                                      // Use a switch statement to get tip based on rating
            {
                case "excellent":                                // Check if the rating is "excellent" and return the tip amount
                    return (int)Math.Ceiling(amount * 0.2);      

                case "great":
                    return (int)Math.Ceiling(amount * 0.15);

                case "good":
                    return (int)Math.Ceiling(amount * 0.1);

                case "poor":
                    return (int)Math.Ceiling(amount * 0.05);

                case "terrible":
                                                                 // No tip for terrible service
                    return 0;
                default:
                                                                 // Return -1 for unrecognized service ratings
                    return -1;
            }
        }
    }
}