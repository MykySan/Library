namespace AnimalHotel.Animals;

public interface IAnimal
{
    string Name { get; set; }
    int Age { get; set; }
    string Color { get; set; }
    Owner Owner { get; }
    void Eat();
    void Sleep();
}