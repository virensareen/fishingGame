using Fishing.Models;

namespace Fishing;

public static class Actions
{
    public static void GoFishing(Player player, List<Lake> allLakes)
    {
        Console.WriteLine("Select the lake you want to go to:");
        for (var i = 0; i < allLakes.Count; i++)
        {
            Console.WriteLine("{0}. {1}", i + 1, allLakes[i].Name);
        }
        Console.WriteLine("Enter the number of the lake:");

        int lakeIndex;
        while (!int.TryParse(Console.ReadLine(), out lakeIndex) || lakeIndex < 1 || lakeIndex > allLakes.Count)
        {
            Console.WriteLine("Invalid input. Please try again.");
        }

        var chosenLake = allLakes[lakeIndex - 1];

        const int fullContainer = 4;
        var rand = new Random();

        var container = new List<Fish>(fullContainer);

        Console.WriteLine("Our container holds {0} fish. Keep the ones you love.", fullContainer);
        Console.WriteLine("Let's fish!");

        while (container.Count < fullContainer)
        {
            var randomFishIndex = rand.Next(chosenLake.AvailableFishes.Count);
            var fishBitesChance = rand.Next(100);

            var currentFish = chosenLake.AvailableFishes[randomFishIndex];

            if (currentFish.BitesBait(fishBitesChance, player.CurrentRod.Buff))
            {
                Console.WriteLine("\nA fish bit your bait! What do you want to do?");
                Console.WriteLine("1. Reel in fish");
                Console.WriteLine("2. Use net\n");

                var input = Console.ReadLine();

                if (Fish.IsCaught(input))
                {
                    Console.WriteLine("\nGot it! Let's see what we caught.");

                    Console.WriteLine(currentFish.Name);
                    Console.WriteLine("");

                    container.Add(currentFish);
                }
                else
                {
                    Console.WriteLine("Oh no! The fish got away. Keep trying!\n\n");
                }
            }
            else
            {
                Console.WriteLine("One minute went by...");
                Thread.Sleep(500);
            }
        }

        Console.WriteLine("We're full! Let's look at what we caught.");

        foreach (var fish in container)
        {
            Console.WriteLine(fish.Name);
        }

        player.Container = container;

        Console.WriteLine("\n\n\n");
    }
    
    public static void GoBassProShop(Player player, List<FishingRod> allRods)
    {
        Console.WriteLine("Welcome to Bass Pro Shop!");
        Console.WriteLine("Here are the fishing rods available:");
        for (var i = 0; i < allRods.Count; i++)
        {
            Console.WriteLine("{0}. {1} - Price: ${2} - Buff: +{3}", i + 1, allRods[i].Name, allRods[i].Price, allRods[i].Buff);
        }
        Console.WriteLine("Enter the number of the rod you'd like to buy or 0 to exit:");

        int rodIndex;
        while (!int.TryParse(Console.ReadLine(), out rodIndex) || rodIndex < 0 || rodIndex > allRods.Count)
        {
            Console.WriteLine("Invalid input. Please try again.");
        }

        if (rodIndex == 0)
        {
            Console.WriteLine("Returning to the main menu.");
            return;
        }

        var chosenRod = allRods[rodIndex - 1];

        if (player.Cash >= chosenRod.Price)
        {
            player.Cash -= chosenRod.Price;
            player.CurrentRod = chosenRod;
            Console.WriteLine("You've successfully bought the {0}!", chosenRod.Name);
        }
        else
        {
            Console.WriteLine("You don't have enough money to buy this rod.");
        }
    }
}