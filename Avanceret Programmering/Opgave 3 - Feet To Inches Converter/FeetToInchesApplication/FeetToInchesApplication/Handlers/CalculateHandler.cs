using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeetToInchesApplication.Handlers
{
    public class CalculateHandler : ICalculateHandler
    {


        public CalculateHandler()
        {
        }

        public static Task<double> CalculateFeetToInches(double feet)
        {
            try
            {
                return Task.FromResult(feet*12);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            
        }

        Task<double> ICalculateHandler.CalculateFeetToInches(double feet)
        {
            return CalculateFeetToInches(feet);
        }


        public static Task<double> CalculateInchesToFeet(double inches)
        {
            try
            {
                return Task.FromResult(inches / 12);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }

        }

        Task<double> ICalculateHandler.CalculateInchesToFeet(double inches)
        {
            return CalculateFeetToInches(inches);
        }

    }
}
