using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date1 = new DateTime(2001, 08, 16);
            DateTime date2 = new DateTime(2005, 03, 06);
            DateTime date3 = new DateTime(1991, 08, 16);

            Edition edition1 = new Edition("Ababagalamaga", date1, 5);
            Edition edition2 = new Edition("Ababagalamaga", date1, 5);

            Console.WriteLine(object.ReferenceEquals(edition1, edition2));

            Console.WriteLine($"first hash code: {edition1.GetHashCode()}");
            Console.WriteLine($"second hash code: {edition2.GetHashCode()}");
            Console.WriteLine($"hash code are equals - {edition1.GetHashCode() == edition2.GetHashCode()}");

            try
            {
                Console.WriteLine("Enter the circulation for edition1: ");
                edition1.Circulation = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine();
            }

            Magazine magazine = new Magazine("Test magazine", Frequency.Weekly, date2, 100);

            Person[] persons = new Person[3];

            persons[0] = new Person("Lesia ", "Ukrainka", date2);
            persons[1] = new Person("Taras", "Shevchenko", DateTime.Today);
            persons[2] = new Person("Ivan", "Franko", date3);


            Article[] articles = new Article[3];

            articles[0] = new Article(persons[0], "Kyiv", 9.4);
            articles[1] = new Article(persons[1], "Lviv", 8.4);
            articles[2] = new Article(persons[2], "Chernivtsi", 5.4);

            magazine.AddArticles(articles[0]);
            magazine.AddArticles(articles[1], articles[2]);

            magazine.AddEditors(persons[0]);
            magazine.AddEditors(persons[1], persons[2]);

            Console.WriteLine(magazine.ToString());

            Console.WriteLine();

            Console.WriteLine($"Property Edition in magazine variable\n {magazine.Edition}");

            var magazineDeepCopy = magazine.DeepCopy();
            magazine.Circulation = 50;
            magazine.Name = "After DeepCopy name";

            Console.WriteLine($"\nReal object\n {magazine}\n\n" +
                $"Copy object\n {magazineDeepCopy}");

            Console.WriteLine();
            foreach (var article in magazine.Articles)
            {
                if (article[8.0f])
                {
                    Console.WriteLine(article.ToString());
                }
            }

            Console.WriteLine();
            foreach (var article in magazine.Articles)
            {
                if (article["e"])
                {
                    Console.WriteLine(article.ToString());
                }
            }


       
        }
    }
}
