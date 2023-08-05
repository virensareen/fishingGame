public class Lake
{
    public string Name { get; }
    public List<Fish> AvailableFishes { get; }

    public Lake(string name, List<Fish> availableFishes)
    {
        Name = name;
        AvailableFishes = availableFishes;
    }
}