using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Fibonacci.Client.Models;

namespace Fibonacci.Client
{
    interface IFibonacciHandler
    {
        Task<ResponseModel> Calculate(long? maxValue);
    }
}
