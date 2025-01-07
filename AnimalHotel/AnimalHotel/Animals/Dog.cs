namespace AnimalHotel.Animals;

public class Dog : IAnimal
{
    private Dog(string name, Owner owner, string color, int age)
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
    
    public void Bark()
    {
        Console.WriteLine($"{nameof(Dog)} is barking");
    }

    public void Eat()
    {
        Console.WriteLine($"{nameof(Dog)} is eating");
    }

    public void Sleep()
    {
        Console.WriteLine($"{nameof(Dog)} is sleeping");
    }
    
    public static Dog CreateDog(string name, Owner owner, string color, int age)
    {
        return new Dog(name, owner, color, age);
    }
}