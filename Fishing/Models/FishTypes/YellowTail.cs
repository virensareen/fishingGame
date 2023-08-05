namespace Fishing.Models.FishTypes;

public class YellowTail : Fish
{
    public YellowTail(int probability) : base(probability)
    {
        MarketPrice = 100;
        Name = "yellowtail";
    }
}