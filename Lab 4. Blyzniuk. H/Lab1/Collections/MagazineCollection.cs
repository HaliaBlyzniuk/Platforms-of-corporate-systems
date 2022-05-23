using Lab1.ComparerClass;
using Lab1.Delegate;
using System.Collections.Generic;
using System.Linq;

namespace Lab1.Collections
{
    class MagazineCollection
    {
        public delegate void MagazineListHandler(object source, MagazineListHandlerEventArgs args);

        public event MagazineListHandler MagazineAdded;
        public event MagazineListHandler MagazineReplaced;

        public string CollectionName { get; set; }
        public List<Magazine> Magazines { get; set; } = new List<Magazine>();

        public bool Replace(int j, Magazine magazine)
        {
            if (Magazines.Count > j)
            {
                Magazines[j] = magazine;
                MagazineReplaced?.Invoke(this,
                    new MagazineListHandlerEventArgs(CollectionName, "Element was replaced by Replace", j));
                return true;
            }
            return false;
        }

        public void AddDefaults()
        {
            Magazines.AddRange(new Magazine[] { TestCollection.GetMegazine(11), 
                TestCollection.GetMegazine(12), 
                TestCollection.GetMegazine(13) });
            MagazineAdded?.Invoke(this, 
                new MagazineListHandlerEventArgs(CollectionName, "Element was added by AddDEfaults", Magazines.Count - 3));
            MagazineAdded?.Invoke(this, 
                new MagazineListHandlerEventArgs(CollectionName, "Element was added by AddDEfaults", Magazines.Count - 2));
            MagazineAdded?.Invoke(this, 
                new MagazineListHandlerEventArgs(CollectionName, "Element was added by AddDEfaults", Magazines.Count - 1));
        }
        public void AddMagazines(params Magazine[] magazines)
        {     
            
            Magazines.AddRange(magazines);
            MagazineAdded?.Invoke(this, 
                new MagazineListHandlerEventArgs(CollectionName, "Element was added by AddMagazines", Magazines.Count - 1));
        }
        public Magazine this[int index]
        {
            get => Magazines[index];
            set
            {
                Magazines[index] = value;
                MagazineReplaced?.Invoke(this, 
                    new MagazineListHandlerEventArgs(CollectionName, "Element was replaced by indexator", index));
            }
        }

        public override string ToString() => $"Magazines:" +
            $"\n{string.Join("\n", Magazines.Select(x => x.ToString()).ToArray())}";

        public virtual string ToShortString() => $"Magazines:" +
            $"\n{string.Join("\n", Magazines.Select(x => x.ToShortString()).ToArray())}";

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
