using System;
using System.Threading.Tasks;
using BmiClient;
using BmiClient.Models;
using Xunit;

namespace BmiTester
{
    public class UnitTestBmi
    {
        private readonly double _weigth = 85.6;
        private readonly double _heigth = 1.87;

        [Fact]
        public void Math_Bmi()
        {

            double bmi = _weigth / (_heigth * _heigth);
            Assert.Equal((decimal)24.4788241013469, (decimal)bmi);
        }

    }
}
