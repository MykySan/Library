using System.Text.RegularExpressions;

Console.WriteLine("Input a number: ");
var input = Console.ReadLine();

if (string.IsNullOrWhiteSpace(input) || !Regex.IsMatch(input, @"^\d+$"))
{
    Console.WriteLine("Invalid input. Please enter a positive integer.");
    return;
}

var number = int.Parse(input);

var binary = Convert.ToString(number, 2);
var hex = Convert.ToString(number, 16);

var isPrime = IsPrime(number);
var isPerfectSquare = IsPerfectSquare(number);

Console.WriteLine($"Number in binary: {binary}");
Console.WriteLine($"Number in hexadecimal: {hex}");
Console.WriteLine($"Is the number prime? {(isPrime ? "Yes" : "No")}");
Console.WriteLine($"Is the number a perfect square? {(isPerfectSquare ? "Yes" : "No")}");

if (Regex.IsMatch(input, @"^[02468]$|^\d\d*[02468]$"))
{
    Console.WriteLine("Number is divisible by 2, 4, 6 or 8");
}
else
{
    Console.WriteLine("Number is not divisible by 2, 4, 6 or 8");
}

static bool IsPrime(int num) => num >= 2 && num switch
{
    2 => true,
    _ when num % 2 == 0 => false,
    _ => !HasDivisor(num)
};

static bool HasDivisor(int num)
{
    for (var i = 3; i <= Math.Sqrt(num); i += 2)
    {
        if (num % i == 0) return true;
    }
    return false;
}

static bool IsPerfectSquare(int num)
{
    var root = (int)Math.Sqrt(num);
    return root * root == num;
}