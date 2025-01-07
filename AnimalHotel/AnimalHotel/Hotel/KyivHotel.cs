using System.Collections;
using AnimalHotel.Animals;

namespace AnimalHotel.Hotel;

public class KyivHotel : IEnumerable<IAnimal>
{
    private int _count = 0;
    private int _capacity = 4;
    private IAnimal[] _animals = new IAnimal[4];

    public void FeedAnimals()
    {
        foreach (var animal in _animals.Where(animal => animal != null))
        {
            animal.Eat();
        }
    }

    public void PutAnimalsToSleep()
    {
        foreach (var animal in _animals.Where(animal => animal != null))
        {
            animal.Sleep();
        }
    }

    public void AddAnimal(IAnimal animal)
    {
        if (_count == _capacity)
        {
            _capacity *= 2;
            Array.Resize(ref _animals, _capacity);
        }

        _animals[_count++] = animal;
    }

    public void PrintAnimals()
    {
        foreach (var animal in _animals.Where(animal => animal != null))
        {
            Console.WriteLine(animal.Name);
        }
    }

    public IAnimal this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException("Invalid index");
            return _animals[index];
        }
        set
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException("Invalid index");
            _animals[index] = value;
        }
    }

    public IEnumerator<IAnimal> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _animals[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<IAnimal> SortByAge()
    {
        return _animals.Where(animal => animal != null).OrderBy(animal => animal.Age);
    }

    public IEnumerable<IAnimal> GetAnimalsByOwnerName(string ownerName)
    {
        return _animals.OfType<IAnimal>().Where(animal => animal.Owner.Name.Equals(ownerName, StringComparison.OrdinalIgnoreCase));
    }
}