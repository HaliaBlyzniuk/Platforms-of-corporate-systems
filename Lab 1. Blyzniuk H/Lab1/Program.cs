using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person(
                "Alex",
                "Arestovych",
                new DateTime(1975, 08, 03)
                );
            Article[] articles = new Article[3];

            articles[0] = new Article(person, "Kyiv", 9.4);
            articles[1] = new Article(person, "Lviv", 5.4);
            articles[2] = new Article(person, "Chernivtsi", 8.4);

            Magazine magazine = new Magazine(
                "Ukraine Now",
                Frequency.Weekly,
                new DateTime(2022, 12, 12),
                1000
                );

            magazine.AddArticles(articles[0]);
            magazine.AddArticles(articles[1], articles[2]);

            Console.WriteLine("ToString()\n");
            Console.WriteLine(magazine.ToString());

            Console.WriteLine("\nToShortString()\n");
            Console.WriteLine(magazine.ToShortString());

            Console.WriteLine(magazine[Frequency.Weekly].ToString());
            Console.WriteLine(magazine[Frequency.Monthly].ToString());
            Console.WriteLine(magazine[Frequency.Yearly].ToString());
        }
    }
}
