namespace Lab2
{
    interface IRateAndCopy
    {
        public double Rating { get; }
        public object DeepCopy();
    }
}
