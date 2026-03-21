using System;
namespace Practical
{

    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter a string");
            String stringovaca = Console.ReadLine();
            String reversedString = "";
            for (int i = stringovaca.Length - 1; i >= 0; i--)
            {
                reversedString += stringovaca[i];
            }

            Console.WriteLine(reversedString);

        }
    }



}


