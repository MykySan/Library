namespace AnimalHotel;

public class Owner
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string PhoneNumber { get; set; }

    public Owner(string name, string phoneNumber, int age)
    {
        Name = name;
        Age = age;
        PhoneNumber = phoneNumber;
    }
}