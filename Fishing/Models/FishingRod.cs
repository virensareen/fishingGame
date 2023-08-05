public class FishingRod
{
    public string Name { get; }
    public int Price { get; }
    public int Buff { get; }

    public FishingRod(string name, int price, int buff)
    {
        Name = name;
        Price = price;
        Buff = buff;
    }
}