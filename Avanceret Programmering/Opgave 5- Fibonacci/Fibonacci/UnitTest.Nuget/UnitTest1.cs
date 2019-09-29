using System.Threading.Tasks;
using Fibonacci.Client;
using NUnit.Framework;

namespace UnitTest.Nuget
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Client_Calculate_OK()
        {
            var handler = new FibonacciHandler();

            var result = await handler.Calculate(4000000);
            Assert.Pass();
        }
    }
}