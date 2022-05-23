using Lab1.Collections;
using Lab1.Delegate;
using System;
using System.Linq;

namespace Lab1
{
    class Program
    {
        ///-------------lab3------------
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

            Console.WriteLine("magazineCollection default: \n {0}\n", string.Join(" ; ", magazineCollection.Magazines.Select(x => x.Name).ToArray()));

            magazineCollection.SortByName();
            Console.WriteLine("Sorted by Name: \n {0}\n", string.Join(" ; ", magazineCollection.Magazines.Select(x => x.Name).ToArray()));

            magazineCollection.SortByDate();
            Console.WriteLine("Sorted by Date: \n {0}\n", string.Join(" ; ", magazineCollection.Magazines.Select(x => x.Name).ToArray()));

            magazineCollection.SortByCirculation();

            Console.WriteLine("Sorted by Circulation: \n {0}\n", string.Join(" ; ", magazineCollection.Magazines.Select(x => x.Name).ToArray()));

            Console.WriteLine("Maximum middle rate: {0}\n", magazineCollection.GetMaxMiddleRate);

            Console.WriteLine("Magazines with Frequency = Monthly:\n {0}\n",
                string.Join(" ; ", magazineCollection.GetMontlyMagazines.Select(x => x.Name).ToArray()));

            int value = 3;
            Console.WriteLine("Magazines with middle rate more then {0}:\n {1}\n", value,
                string.Join(" ; ", magazineCollection.GetRatingGroup(value).Select(x => x.Name).ToArray()));

            TestCollection test = new TestCollection(10);
            Console.WriteLine("Searching time:");
            test.MeasureTime();


            ///-----------lab4---------------
            /*MagazineCollection mag1 = new MagazineCollection();
            MagazineCollection mag2 = new MagazineCollection();
            mag1.CollectionName = "mag1";
            mag2.CollectionName = "mag2";

            Listener lis1 = new Listener();
            mag1.MagazineAdded += lis1.AddEvent;
            mag1.MagazineReplaced += lis1.AddEvent;

            Listener lis2 = new Listener();
            mag1.MagazineAdded += lis2.AddEvent;
            mag2.MagazineAdded += lis2.AddEvent;
            mag1.MagazineReplaced += lis2.AddEvent;
            mag2.MagazineReplaced += lis2.AddEvent;  
            
            mag1.AddMagazines(new Magazine());
            mag2.AddMagazines(new Magazine());
            mag1.AddDefaults();
            mag2.AddDefaults();

            mag1.Magazines.Remove(mag1[2]);
            mag2.Magazines.Remove(mag2[2]);

            mag1.AddDefaults();
            mag2.AddDefaults();

            mag1[2] = new Magazine();
            mag1.Replace(5, new Magazine());
            mag2[2] = new Magazine();
            mag2.Replace(1, new Magazine());
           
            Console.WriteLine("-------------LISTENER-1-------------");
            Console.WriteLine(lis1);
            Console.WriteLine("-------------LISTENER-2-------------");
            Console.WriteLine(lis2);

            Console.ReadKey();*/
        }
    }
}
