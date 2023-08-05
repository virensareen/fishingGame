namespace Fishing.Models.FishTypes;

public class Catfish : Fish
{
    public Catfish(int probability) : base(probability)
    {
        MarketPrice = 10;
        Name = "catfish";
    }
}