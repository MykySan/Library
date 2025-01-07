namespace AnimalHotel.Animals;

public class AnimalFactory
{
    private static readonly string[] Colors = { "Black", "White", "Brown", "Gray"};
    private static readonly Random Random = new();
    public static Dog CreateDog(string name, Owner owner)
    {
        return Dog.CreateDog(name, owner, Colors[Random.Next(Colors.Length)], Random.Next(1,15));
    }
    
    public static Cat CreateCat(string name, Owner owner)
    {
        return Cat.CreateCat(name, owner, Colors[Random.Next(Colors.Length)], Random.Next(1,15));
    }
}