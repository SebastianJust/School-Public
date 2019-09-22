using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleApplicationSumOfMultiplier.Library;

namespace ConsoleApplicationSumOfMultiplier
{
    class Program
    {
        private static readonly List<(int r, int val1, int val2)> Cases = new List<(int r, int val1, int val2)>
        {
            (10, 3, 5),
            (1000, 3, 5),
            (100000, 4, 6),
        };

        static async Task Main()
        {
            DateTime dateStarted = DateTime.Now;
            
            Console.Write($"Application has started at {DateTime.Now}...");

            List<(int range, long result)> results = await Calculation(Cases);

            bool running = true;
            while (running)
            {
                string question = "Do you want to see the results?";
                Console.Write($"{question} (Y/N):");
                string a = Console.ReadLine();

                bool showResults = a != null && a.Equals("y", StringComparison.OrdinalIgnoreCase);
                if (!showResults)
                {
                    Console.WriteLine("Application has stopped...");
                    break;
                }
                {
                    foreach ((int range, long result) r in results)
                    {
                        Console.WriteLine($"Result under {r.range} is: {r.result}");
                    }

                    TimeSpan timeSpent = DateTime.Now - dateStarted;
                    Console.WriteLine($"Application has ended at {DateTime.Now}...");
                    Console.WriteLine($"TIME SPENT: {timeSpent}");

                    running = false;
                }

            }

        }

        private static async Task<List<(int range, long result)>> Calculation(List<(int r, int val1, int val2)> cases)
        {
            List<(int range, long result)> resultsList = new List<(int range, long result)>();

            try
            {
                foreach (var (i, val1, val2) in cases)
                {
                    long r = await CalculateHandler.GetSumMultipliers(i, val1, val2);
                    resultsList.Add((i, r));
                }

                return resultsList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

}
