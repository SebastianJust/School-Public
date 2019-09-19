using System;
using System.Xml.Schema;
using Xunit;

namespace UnitTestCalculations
{
    public class UnitTest
    {
        [Fact]
        public void Test_InchesToFeet_1()
        {
            double inches = 100;
            double calcualtion = inches / 12;
            var actual = calcualtion.ToString().Substring(0, 6);
            Assert.Equal("0,0833ft", $"{actual}ft"); //Do to: https://www.rapidtables.com/convert/length/inch-to-feet.html

        
        }

        [Fact]
        public void Test_InchesToFeet_100()
        {
            double inches = 100;
            double calcualtion = inches / 12;
            var actual = calcualtion.ToString().Substring(0, 6);
            Assert.Equal("8,3333ft", $"{actual}ft"); //Do to: https://www.rapidtables.com/convert/length/inch-to-feet.html
        }


        [Fact]
        public void Test_FeetToInches_8()
        {
            double feet = 8;
            double calcualtion = feet * 12;
            var actual = calcualtion;
            Assert.Equal("96''", $"{actual}''"); //Do to: https://www.rapidtables.com/convert/length/inch-to-feet.html
        }
    }
}
