using Fishing.Models;
using Fishing.Models.FishTypes;

namespace Fishing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Add new lakes here if needed
            var all_lakes = new List<Lake>()
            {
                new Lake("Lake Tahoe", new List<Fish>()
                {
                    new Catfish(35),
                    new Albacore(20),
                    new Bluefin(5)
                }),
                new Lake("Big Bear lake", new List<Fish>()
                {
                    new Catfish(30),
                    new Albacore(35),
                    new YellowTail(15),
                })
            };

            var all_rods = new List<FishingRod>()
            {
                new FishingRod("Bamboo Stick", 0, 0),
                new FishingRod("Swift Model E", 50, 2),
                new FishingRod("Perry Water Eye Gouger", 200, 6),
                new FishingRod("The Senator", 400, 10),
                new FishingRod("Ocean Depleter", 1000, 20),
            };

            var player = new Player();

            Console.WriteLine("Welcome to deep sea fishing!");
            Console.WriteLine("---------");

            var isGameRunning = true;

            while (isGameRunning)
            {
                Console.WriteLine("Cash: ${0}", player.Cash);
                Console.WriteLine("Current rod: {0} (+{1} buff)", player.CurrentRod.Name, player.CurrentRod.Buff);
                Console.WriteLine("---------");
                Console.WriteLine("1. Go fishing");
                Console.WriteLine("2. Bass pro shop");
                Console.WriteLine("3. Sell fish");
                Console.WriteLine("4. Quit game");
                Console.WriteLine("What would you like to do?");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Actions.GoFishing(player, all_lakes);
                        break;
                    case "2":
                        Actions.GoBassProShop(player, all_rods);
                        break;
                    case "3":
                        player.SellFish();
                        break;
                    case "4":
                        isGameRunning = false;
                        Console.WriteLine("Thank you for playing!");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }
    }
}