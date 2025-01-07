using System.Collections;
using AnimalHotel.Animals;

namespace AnimalHotel.Hotel;

public class GenericHotel<T> : IEnumerable<T> where T : IAnimal
{
    private int _count = 0;
    
    private int _capacity = 4;
    
    private T[] _animals = new T[4];
    
    public void FeedAnimals()
    {
        foreach (var animal in _animals)
        {
            animal.Eat();
        }
    }
    
    public void PutAnimalsToSleep()
    {
        foreach (var animal in _animals)
        {
            animal.Sleep();
        }
    }
    
    public void AddAnimal(T animal)
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
        foreach (var animal in _animals)
        {
            Console.WriteLine(animal.Name);
        }
    }
    
    public T this[int index]
    {
        get => _animals[index];
        set => _animals[index] = value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for(var i = 0; i < _count; i++)
        {
            yield return _animals[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<T> SortByAge()
    {
        return _animals.Take(_count).OrderBy(animal => animal.Age);
    }
    
    public IEnumerable<T> GetAnimalsByOwnerName(string ownerName)
    {
        return _animals.Take(_count).Where(animal => animal.Owner.Name.Equals(ownerName, StringComparison.OrdinalIgnoreCase));
    }

}