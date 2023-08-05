namespace Fishing.Models;

public class Player
{
    public int Cash { get; set; }
    public FishingRod CurrentRod { get; set; }
    public List<Fish> Container { get; set; }

    public Player()
    {
        Cash = 0;
        CurrentRod = new FishingRod("Bamboo Stick", 0, 0);
        Container = new List<Fish>();
    }
    
    public void SellFish()
    {
        if (Container.Count == 0)
        {
            Console.WriteLine("Your container is empty. Go fishing and come back when you have fish to sell.");
            return;
        }

        var earnings = Container.Sum(fish => fish.MarketPrice);

        Cash += earnings;
        Container.Clear();
        Console.WriteLine("You've sold all the fish in your container for ${0}.", earnings);
    }
}