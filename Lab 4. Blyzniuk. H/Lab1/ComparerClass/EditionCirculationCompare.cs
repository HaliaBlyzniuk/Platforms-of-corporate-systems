using System.Collections.Generic;

namespace Lab1.ComparerClass
{
    internal class EditionCirculationCompare : IComparer<Edition>
    {
        public int Compare(Edition x, Edition y) => x.Circulation.CompareTo(y.Circulation) != 0
            ? x.Circulation.CompareTo(y.Circulation)
            : 0;
    }
}
