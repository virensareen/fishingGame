namespace Fishing.Models.FishTypes;

public class Albacore : Fish
{
    public Albacore(int probability) : base(probability)
    {
        MarketPrice = 50;
        Name = "albacore";
    }
}