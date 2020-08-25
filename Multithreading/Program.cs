using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Multithreading
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Print(UsePlinqNotInORder(new List<int>() { 6, 12, 8, 13, 4, 5, 10, 19, 7, 22 }));
            Console.WriteLine("....");
            Print(UsePlinqInORder(new List<int>() { 6, 12, 8, 13, 4, 5, 10, 19, 7, 22 }));

            string path = @"C:\Users\thelittlecitizen16\Desktop\empire.txt";

            await AddFile(path);

            StreamWriter streamWriter = new StreamWriter(path, true);
           await streamWriter.WriteLineAsync("a");
            streamWriter.Close();

            Console.ReadLine();
        }

        public static async Task AddFile(string path)
        {
            if (!File.Exists(path))
            {
                 File.Create(path);
            }
        }
        public static void Print(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        public static IEnumerable<int> UsePlinqNotInORder(IEnumerable<int> numbers)
        {
           return  numbers.AsParallel().Where(n => n % 3 == 1).Select(n=>n);
        }
        public static IEnumerable<int> UsePlinqInORder(IEnumerable<int> numbers)
        {
            return numbers.AsParallel().Where(n => n % 3 == 1).ToList();
        }
    }
}
