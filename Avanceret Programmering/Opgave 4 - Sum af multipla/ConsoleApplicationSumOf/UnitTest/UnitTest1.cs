using System;
using System.Collections.Generic;
using ConsoleApplicationSumOf.Libary;
using ConsoleApplicationSumOfMultiplier.Library;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {

        [Fact]
        //S = (n(n+1))/2
        public void CheckFormular_Calculate_OK()
        {
            int n = 100;
            int calculate = n * (n + 1) / 2;
            Assert.Equal(5050, calculate);
        }

        [Fact]
        public async void TestCalculateHandler_GetSum_OK23()
        {
           Assert.Equal(23, await CalculateHandler.GetSumMultipliers(10, 3, 5));
        }
        [Fact]
        public async void TestCalculateHandler_GetSum_OK1666583334()
        {
            Assert.Equal(1666583334, await CalculateHandler.GetSumMultipliers(100000, 4, 6));
        }
    }
}
