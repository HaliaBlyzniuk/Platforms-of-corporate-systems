using System;

namespace Lab6
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class CoupleAttribute : Attribute
    {
        public string Pair { get; set; }
        public double Probability { get; set; }
        public string ChildType { get; set; }

        public CoupleAttribute()
        {
        }

        public CoupleAttribute(string pair, double probability, string childType)
        {
            this.Pair = pair;
            this.Probability = probability;
            this.ChildType = childType;
        }
    }
}
