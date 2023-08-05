public class Fish
{
    public string Name { get; set; }
    public int MarketPrice { get; set; }
    public int BiteProbability { get; set; }

    public Fish(int probability)
    {
        BiteProbability = probability;
    }

    internal virtual bool BitesBait(int chance, int rodBuff)
    {
        return chance < BiteProbability + rodBuff;
    }

    internal static bool IsCaught(string input)
    {
        return input == "1";
    }
}