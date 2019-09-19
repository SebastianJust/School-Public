using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeetToInchesApplication.Handlers
{
    interface ICalculateHandler
    {
        Task<double> CalculateFeetToInches(double feet);
        Task<double> CalculateInchesToFeet(double inches);
    }
}
