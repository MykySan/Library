namespace AnimalHotel.Animals;

public class Cat : IAnimal, IComparable<Cat>
{
    private Cat(string name, Owner owner, string color, int age)
    {
        Name = name;
        Owner = owner;
        Color = color;
        Age = age;
    }
    public string Name { get; set; }
    public Owner Owner { get; private set; }
    public string Color { get; set; }
    public int Age { get; set; }
    
    public void Meow()
    {
        Console.WriteLine($"{nameof(Cat)} is meowing");
    }
    
    public void Eat()
    {
        Console.WriteLine($"{nameof(Cat)} is eating");
    }

    public void Sleep()
    {
        Console.WriteLine($"{nameof(Cat)} is sleeping");
    }
    
    public static Cat CreateCat(string name, Owner owner, string color, int age)
    {
        return new Cat(name, owner, color, age);
    }

    public int CompareTo(Cat? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        return Age.CompareTo(other.Age);
    }
}