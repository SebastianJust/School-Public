using System;
using System.Threading.Tasks;
using ConsoleApplicationSumOf.Libary;

namespace ConsoleApplicationSumOfMultiplier.Library
{
    public class CalculateHandler : ICalculateHandler
    {
        private readonly ICalculateHandler _calculateHandlerImplementation;

        public CalculateHandler(ICalculateHandler calculateHandlerImplementation)
        {
            _calculateHandlerImplementation = calculateHandlerImplementation;
        }

        async Task<long> ICalculateHandler.GetSumMultipliers(int range, int val1, int val2)
        {
            return await _calculateHandlerImplementation.GetSumMultipliers(range, val1, val2);
        }

        /// <summary>
        ///Logic to get sum of Multipliers
        /// </summary>
        /// <param name="range">Range of what to calculate</param>
        /// <param name="val1">Multiple value 1</param>
        /// <param name="val2">Multiple value 2</param>
        /// <returns></returns>
        public static async Task<long> GetSumMultipliers(int range, int val1, int val2)
        {
            try
            {
                range -= 1;
                int commonMultiplier = (val1 * val2) / await RemoveDoubles(val1, val2);
                long r = await CalculateSum(range, val1) + await CalculateSum(range, val2) - await CalculateSum(range, commonMultiplier); //Result
                return r;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Removes the doubles in the array
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static async Task<int> RemoveDoubles(int a, int b)
        {
            Console.WriteLine($"Started to remove doubles of {a} & {b}");

            return await Task.FromResult(b == 0 ? a : await RemoveDoubles(b, a % b));
        }

        /// <summary>
        ///Calculating the sum
        /// </summary>
        /// <param name="maxNumber">max value of numbers</param>
        /// <param name="val">values</param>
        /// <returns></returns>
        private static async Task<long> CalculateSum(int maxNumber, int val)
        {
            Console.WriteLine($"Calculating sum...");

            int n = maxNumber / val;
            long sum = (n * (n + 1) / 2) * val;
            return await Task.FromResult(sum);
        }

    }
}
