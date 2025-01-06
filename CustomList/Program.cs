using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            IExpandable expandableList = new CustomList<int>();
            var list = expandableList as CustomList<int>;

            if (list == null)
            {
                Console.WriteLine("Failed to cast list to CustomList<int>");
                return;
            }
            
            expandableList.OnExpandedEvent += () => Console.WriteLine("The array has been expanded.");
            
            Console.WriteLine("Adding elements to the list.");
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(40);
            list.Add(50);
            
            Console.WriteLine($"\nElement at index 2: {list[2]}");
            
            Console.WriteLine("\nFiltered and sorted list");
            var filtered = list.Where(x=>x>20).OrderBy(x=>x);
            Console.WriteLine(string.Join(", ", filtered));
            
            Console.WriteLine("\nAll elements in the list:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            try
            {
                Console.WriteLine(list[10]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nException caught: {ex.Message}");
            }
        }
    }
}