using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LinqTasks
{
    public static class Tasks
    {
        public static void Task1_FilterStrings()
        {
            List<string> words = new List<string> { "Apple", "Banana", "Cherry", "Avocado", "Apricot" };
            var filteredWords = words.Where(word => word.StartsWith("A"));

            Console.WriteLine("Words starting with `A`:");
            foreach (var word in filteredWords)
            {
                Console.WriteLine(word);
            }
        }

        public static void Task2_CommonElements()
        {
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 4, 7, 5, 9 };

            var commonElements = array1.Intersect(array2);
            Console.WriteLine("The common elements are:");
            foreach (var element in commonElements)
            {
                Console.WriteLine(element);
            }
        }

        public static void Task3_TopStudent()
        {
            List<Student> students = new List<Student>
            {
                new Student { FirstName = "John", LastName = "Doe", Grade = 85 },
                new Student { FirstName = "Mykyta", LastName = "Ivashchenko", Grade = 90 },
                new Student { FirstName = "Danylo", LastName = "Hask", Grade = 95 }
            };
            var topStudent = students.OrderByDescending(s => s.Grade).FirstOrDefault();
            Console.WriteLine($"Top Student: {topStudent.FirstName} {topStudent.LastName} Grade: {topStudent.Grade}");
        }

        public static void Task4_AvgPriceByCategory()
        {
            List<Product> products = new List<Product>
            {
                new Product { ProductName = "LapTop", Price = 1000, Category = "Electronics" },
                new Product { ProductName = "Phone", Price = 800, Category = "Electronics" },
                new Product { ProductName = "T-Shirt", Price = 100, Category = "Clothing" },
                new Product { ProductName = "Pants", Price = 80, Category = "Clothing" }
            };
            var averagePrices = products
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, AveragePrice = g.Average(p => p.Price) });
            var cultureInfo = new CultureInfo("en-US");
            Console.WriteLine("Average prices by Category:");
            foreach (var category in averagePrices)
            {
                Console.WriteLine($"{category.Category}, {category.AveragePrice.ToString("C",cultureInfo)}");
            }
        }

        public static void Task5_ExperiencedEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    FirstName = "Alex", LastName = "White", Birthday = new DateTime(1985, 5, 15),
                    HireDate = new DateTime(2015, 6, 1)
                },
                new Employee
                {
                    FirstName = "Ben", LastName = "Big", Birthday = new DateTime(1990, 8, 25),
                    HireDate = new DateTime(2017, 7, 15)
                }
            };
            var experiencedEmployees = employees.Where(e => (DateTime.Now - e.HireDate).TotalDays > 365 * 5);
            Console.WriteLine("Employees with more than 5 years of experienced:");
            foreach (var employee in experiencedEmployees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}");
            }
        }

        public static void Task6_SciFiBooks()
        {
            List<Book> books = new List<Book>
            {
                new Book { Title = "Dune", Author = "Frank Herbert", Year = 1965, Genre = "Sci-Fi" },
                new Book { Title = "Neuromance", Author = "William Gibson", Year = 1984, Genre = "Sci-Fi" },
                new Book { Title = "The Martian", Author = "Andy Weir", Year = 2014, Genre = "Sci-Fi" }
            };
            var recentSciFiBooks = books.Where(b => b.Year > 2010 && b.Genre == "Sci-Fi");
            Console.WriteLine("Recent Sci-Fi books:");
            foreach (var book in recentSciFiBooks)
            {
                Console.WriteLine($"{book.Title}, {book.Author}, {book.Year}");
            }
        }

        public static void Task7_HighValueCustomers()
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer { Name = "Andriy", Address = "Kyiv", OrderTotal = 1200 },
                new Customer { Name = "Alice", Address = "Lviv", OrderTotal = 800 },
                new Customer { Name = "Anna", Address = "Odessa", OrderTotal = 1500 }
            };
            var highValueCustomers = customers.Where(c => c.OrderTotal > 1000);
            Console.WriteLine("Customers with orders over 1000 UAH:");
            foreach (var customer in highValueCustomers)
            {
                Console.WriteLine($"{customer.Name}, {customer.Address}, {customer.OrderTotal}");
            }
        }
    }
}