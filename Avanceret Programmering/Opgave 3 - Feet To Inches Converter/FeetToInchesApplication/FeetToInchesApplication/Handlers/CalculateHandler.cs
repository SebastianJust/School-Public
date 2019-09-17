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



    }
}
