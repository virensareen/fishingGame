namespace Fishing.Models.FishTypes;

public class Bluefin : Fish
{
    public Bluefin(int probability) : base(probability)
    {
        MarketPrice = 500;
        Name = "bluefin";
    }
}