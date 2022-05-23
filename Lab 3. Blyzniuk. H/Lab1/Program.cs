using Lab1.Collections;
using System;
using System.Linq;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            MagazineCollection magazineCollection = new MagazineCollection();
            magazineCollection.AddMagazines(
                    TestCollection.GetMegazine(3),
                    TestCollection.GetMegazine(5),
                    TestCollection.GetMegazine(1),
                    TestCollection.GetMegazine(4),
                    TestCollection.GetMegazine(2)
                );
            
            Console.WriteLine($"magazineCollection default:" +
                $"\n {string.Join(" ; ", magazineCollection.Magazines.Select(x => x.Name).ToArray())}\n");

            magazineCollection.SortByName();
            Console.WriteLine($"Sorted by Name:" +
                $"\n {string.Join(" ; ", magazineCollection.Magazines.Select(x => x.Name).ToArray())}\n");

            magazineCollection.SortByDate();
            Console.WriteLine($"Sorted by Date:" +
                $"\n {string.Join(" ; ", magazineCollection.Magazines.Select(x => x.Date).ToArray())}\n");

            magazineCollection.SortByCirculation();

            Console.WriteLine($"Sorted by Circulation:" +
                $"\n {string.Join(" ; ", magazineCollection.Magazines.Select(x => x.Circulation).ToArray())}\n");

            Console.WriteLine($"Maximum middle rate: {magazineCollection.GetMaxMiddleRate}\n");

            Console.WriteLine($"Magazines with Frequency = Monthly:" +
                $"\n {string.Join(" ; ", magazineCollection.GetMontlyMagazines.Select(x => x.Name).ToArray())}\n");

            int value = 3;
            Console.WriteLine($"Magazines with middle rate more then {value}:" +
                $"\n {string.Join(" ; ", magazineCollection.GetRatingGroup(value).Select(x => x.Name).ToArray())}\n");

            TestCollection test = new TestCollection(10);
            Console.WriteLine("Searching time: ");
            test.MeasureTime();
            
        }
    }
}
