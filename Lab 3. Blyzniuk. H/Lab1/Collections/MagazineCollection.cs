using Lab1.ComparerClass;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1.Collections
{
    class MagazineCollection
    {
        public List<Magazine> Magazines { get; set; }
        public void AddDefaults()
        {
            Magazines = new List<Magazine>();
            Magazine defaultMagazine = new Magazine("name33", Frequency.Monthly, DateTime.Now, 10,
                new List<Person>
                {
                    new Person(), new Person()
                },
                new List<Article>
                {
                    new Article(new Person(), "1", 50 ), new Article(new Person(), "2", 80 )
                });
            Magazines.Add(defaultMagazine);
            Magazines.Add(new Magazine());
            Magazines.Add(defaultMagazine);
        }
        public void AddMagazines(params Magazine[] magazines)
        {
            Magazines = new List<Magazine>();
            Magazines.AddRange(magazines);
        }
        public override string ToString() => 
            $"Magazines:\n{string.Join("\n", Magazines.Select(x => x.ToString()).ToArray())}";

        public virtual string ToShortString() => 
            $"Magazines:\n{string.Join("\n", Magazines.Select(x => x.ToShortString()).ToArray())}";

        public void SortByName() => Magazines.Sort();

        public void SortByDate() => Magazines.Sort(new Edition().Compare);

        public void SortByCirculation() => Magazines.Sort(new EditionCirculationCompare().Compare);

        public double GetMaxMiddleRate
        {
            get => Magazines.Count != 0 ? Magazines.Select(x => x.MiddleRate).Max() : 0;
        }

        public IEnumerable<Magazine> GetMontlyMagazines
        {
            get => Magazines.Where(x => x.Periodicity == Frequency.Monthly);
        }

        public List<Magazine> GetRatingGroup(double value) => Magazines.Where(x => x.MiddleRate >= value).ToList();
    }
}
