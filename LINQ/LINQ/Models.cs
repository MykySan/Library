namespace LinqTasks
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
    }

    public class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime HireDate { get; set; }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal OrderTotal { get; set; }
    }
}