using AnimalHotel;
using AnimalHotel.Animals;
using AnimalHotel.Hotel;

var animalNames = new string[] { "Dog", "Cat", "Parrot", "Horse" };
var ownerNames = new string[] { "John", "Jane", "Jack", "Jill" };
var ownerPhoneNumbers = new string[] { "1234567890", "0987654321", "6789054321", "1234509876" };
var ownerAges = new int[] { 25, 30, 35, 40 };
var random = new Random();

var genericHotel = new GenericHotel<IAnimal>();
var romashkaHotel = new RomashkaHotel();
var kyivHotel = new KyivHotel();

for (int i = 0; i < 10; i++)
{
    var animalName = animalNames[random.Next(animalNames.Length)];
    var ownerName = ownerNames[random.Next(ownerNames.Length)];
    var ownerPhoneNumber = ownerPhoneNumbers[random.Next(ownerPhoneNumbers.Length)];
    var animalType = random.Next(2);
    var ownerAge = ownerAges[random.Next(ownerAges.Length)];

    var owner = new Owner(ownerName, ownerPhoneNumber, ownerAge);
    IAnimal animal = animalType switch
    {
        0 => AnimalFactory.CreateDog(animalName, owner),
        1 => AnimalFactory.CreateCat(animalName, owner),
        _ => throw new ArgumentException("Invalid animal type")
    };

    genericHotel.AddAnimal(animal);
    romashkaHotel.AddAnimal(animal);
    kyivHotel.AddAnimal(animal);
}

Console.WriteLine("Animals in GenericHotel:");
foreach (var animal in genericHotel)
{
    Console.WriteLine($"{animal.Name}, Age: {animal.Age}, Color: {animal.Color}");
}

Console.WriteLine("\nAnimals in RomashkaHotel:");
foreach (var animal in romashkaHotel)
{
    if (animal is IAnimal iAnimal)
    {
        Console.WriteLine($"{iAnimal.Name}, Age: {iAnimal.Age}, Color: {iAnimal.Color}");
    }
}

Console.WriteLine("\nAnimals in KyivHotel:");
foreach (var animal in kyivHotel)
{
    Console.WriteLine($"{animal.Name}, Age: {animal.Age}, Color: {animal.Color}");
}

Console.WriteLine("\nAnimals starting with 'Parrot' in GenericHotel:");
var parrotAnimalsGeneric = genericHotel.Where(animal => animal != null && animal.Name.StartsWith("Parrot", StringComparison.OrdinalIgnoreCase));
foreach (var animal in parrotAnimalsGeneric)
{
    Console.WriteLine($"{animal.Name}, Age: {animal.Age}, Color: {animal.Color}");
}

Console.WriteLine("\nAnimals starting with 'Parrot' in RomashkaHotel:");
var parrotAnimalsRomashka = romashkaHotel
    .OfType<IAnimal>()
    .Where(animal => animal.Name.StartsWith("Parrot", StringComparison.OrdinalIgnoreCase));
foreach (var animal in parrotAnimalsRomashka)
{
    Console.WriteLine($"{animal.Name}, Age: {animal.Age}, Color: {animal.Color}");
}

Console.WriteLine("\nAnimals starting with 'Parrot' in KyivHotel:");
var parrotAnimalsKyiv = kyivHotel
    .Where(animal => animal != null && animal.Name.StartsWith("Parrot", StringComparison.OrdinalIgnoreCase));
foreach (var animal in parrotAnimalsKyiv)
{
    Console.WriteLine($"{animal.Name}, Age: {animal.Age}, Color: {animal.Color}");
}

Console.WriteLine("\nAnimals sorted by age in GenericHotel:");
foreach (var animal in genericHotel.SortByAge())
{
    Console.WriteLine($"{animal.Name}, Age: {animal.Age}, Owner: {animal.Owner.Name}, Color: {animal.Color}");
}

Console.WriteLine("\nEnter owner's name to find their animals:");
string? ownerNameToSearch = Console.ReadLine();
if (!string.IsNullOrWhiteSpace(ownerNameToSearch))
{
    var animalsByOwner = genericHotel.GetAnimalsByOwnerName(ownerNameToSearch);
    Console.WriteLine($"\nAnimals owned by {ownerNameToSearch}:");
    foreach (var animal in animalsByOwner)
    {
        Console.WriteLine($"{animal.Name}, Age: {animal.Age}, Color: {animal.Color}");
    }
}
else
{
    Console.WriteLine("Owner name cannot be null or empty.");
}
