namespace Lab1
{
    interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }
}
