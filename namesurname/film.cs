using System;
using System.Collections.Generic;

namespace FilmApp
{

    interface IBoxOffice
    {
        void PrintEarnings();
    }


    class Film
    {
        private string name;
        private string director;
        private int year;
        private string genre;
        public List<double> Ratings { get; set; } = new List<double>();


        public Film() { }


        public Film(string name, string director, int year, string genre)
        {
            this.name = name;
            this.director = director;
            this.year = year;
            this.genre = genre;
        }


        ~Film() { }


        public string Name { get => name; set => name = value; }
        public string Director { get => director; set => director = value; }
        public int Year { get => year; set => year = value; }
        public string Genre { get => genre; set => genre = value; }


        public virtual void PrintInfo()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Director: {director}");
            Console.WriteLine($"Year: {year}");
            Console.WriteLine($"Genre: {genre}");
        }


        public virtual void CalcucalteAverageRating(List<double> ratings) { }
    }


    class Rating : Film
    {

        public Rating(string name, string director, int year, string genre)
            : base(name, director, year, genre) { }

        // Override PrintInfo to print ratings
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Rating: {AverageRating():F2}");
        }


        public override void CalcucalteAverageRating(List<double> ratings)
        {
            double sum = 0;
            foreach (var r in ratings)
                sum += r;
            Console.WriteLine($"Average Rating: {(sum / ratings.Count):F2}");
        }

        private double AverageRating()
        {
            double sum = 0;
            foreach (var r in Ratings)
                sum += r;
            return Ratings.Count > 0 ? sum / Ratings.Count : 0;
        }
    }


    class BoxOffice : IBoxOffice
    {
        private List<double> allEarnings = new List<double>();

        public void PrintEarnings()
        {
            Console.WriteLine("Earnings:");
            foreach (var e in allEarnings)
                Console.WriteLine(e);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert Film Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Please insert Film Director:");
            string director = Console.ReadLine();

            Console.WriteLine("Please insert film year:");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Please insert film genre:");
            string genre = Console.ReadLine();

            Rating film = new Rating(name, director, year, genre);

            Console.WriteLine("Please start inserting film ratings between 0 and 5. To stop, please insert \"/\":");

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "/")
                    break;

                try
                {
                    double rating = Double.Parse(input);

                    if (rating < 0 || rating > 5)
                        Console.WriteLine("You have entered incorrect rating. Allowed rating should be between 0 and 5!");
                    else
                        film.Ratings.Add(rating);
                }
                catch
                {
                    Console.WriteLine("Invalid input, please enter a number.");
                }
            }

            film.PrintInfo();

            Console.ReadLine();
        }
    }
}