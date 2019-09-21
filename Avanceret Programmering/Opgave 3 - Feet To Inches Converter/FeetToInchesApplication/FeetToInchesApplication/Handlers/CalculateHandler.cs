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

        public static async Task<double> CalculateFeetToInches(double feet)
        {
            try
            {
                return await Task.FromResult(feet*12);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            
        }

        async Task<double> ICalculateHandler.CalculateFeetToInches(double feet)
        {
            return await CalculateFeetToInches(feet);
        }


        public static async Task<double> CalculateInchesToFeet(double inches)
        {
            try
            {
                return await Task.FromResult(inches / 12);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }

        }

        async Task<double> ICalculateHandler.CalculateInchesToFeet(double inches)
        {
            return await CalculateFeetToInches(inches);
        }

    }
}
