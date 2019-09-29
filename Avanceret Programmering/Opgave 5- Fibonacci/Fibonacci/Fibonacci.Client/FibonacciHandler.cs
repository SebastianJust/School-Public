using System;
using System.Threading.Tasks;
using Fibonacci.Client.Models;
using Microsoft.Extensions.Logging;

namespace Fibonacci.Client
{
    public class FibonacciHandler : IFibonacciHandler
    {
        /// <inheritdoc />
        public FibonacciHandler()
        {
        }


        /// <summary>
        /// Calculate Equals and Odd sum in Fibonacci
        /// </summary>
        /// <param name="maxValue">Max value of sum</param>
        /// <returns></returns>
        public async Task<ResponseModel> Calculate(long? maxValue)
        {
            if (maxValue == null)
                throw new ArgumentNullException($"{nameof(maxValue)} cannot be null");
            long a = 0, b = 1, c = 0;
            long e = 0;
            long o = 0;

            try
            {
                while (c < maxValue)

                {

                    c = a + b;

                    a = b;

                    b = c;


                    if (c % 2 == 0)
                        e += c;

                    else
                        o += c;
                }

            }

            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            ResponseModel result = new ResponseModel{Equal = e, Odd = o};
            return await Task.FromResult(result);
        }
    }
}
