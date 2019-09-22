using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationSumOf.Libary
{
    public interface ICalculateHandler
    {
        Task<long> GetSumMultipliers(int range, int val1, int val2);

    }
}
