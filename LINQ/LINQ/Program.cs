using System;

namespace LinqTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nSelect a task to run:");
                Console.WriteLine("1. Filter strings starting with `A`");
                Console.WriteLine("2. Find common elements in two arrays");
                Console.WriteLine("3. Find the student with highest grades");
                Console.WriteLine("4. Calculate average price of products by category");
                Console.WriteLine("5. Find employees with more than 5 years experience");
                Console.WriteLine("6. Find Sci-Fi books published after 2010");
                Console.WriteLine("7. Find customers with orders over 1000 UAH");
                Console.WriteLine("0. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Tasks.Task1_FilterStrings();
                        break;
                    case "2":
                        Tasks.Task2_CommonElements();
                        break;
                    case "3":
                        Tasks.Task3_TopStudent();
                        break;
                    case "4":
                        Tasks.Task4_AvgPriceByCategory();
                        break;
                    case "5":
                        Tasks.Task5_ExperiencedEmployees();
                        break;
                    case "6":
                        Tasks.Task6_SciFiBooks();
                        break;
                    case "7":
                        Tasks.Task7_HighValueCustomers();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}