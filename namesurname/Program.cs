using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace namesurname
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("enter a year ");
            int year = Console.Read();


            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    Console.WriteLine("it is a leap year");
                }
                else
                {
                    Console.WriteLine("it is not a leap year");
                }



            }
            else
            {
                Console.WriteLine("it is not a leap year");
            }


        }
    }

}