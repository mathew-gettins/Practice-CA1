using System.Net.NetworkInformation;

namespace Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string status = "";
            int years = 0; 
            double hours = 0;
            status = "";

            string[] name = new string[1];
            double[] wages= new double[1];


            for (int i = 0; i < name.Length; i++)
            {
                Console.Write("Enter Name         : ");
                name[i] = Console.ReadLine();

                Console.Write("Status (W/H)       : ");
                status = Console.ReadLine();    

                Console.Write("Enter hours        : ");
                hours = double.Parse(Console.ReadLine());

                Console.Write("Enter years    : ");
                years = int.Parse(Console.ReadLine());

                Console.Write($"{name[i]} you have worked {hours} and your wages are {Wages}"); 

            }

        static int Wages()
            {   
                if (status = "w")
                {

                }
                return 0;

            }




        }
    }
}