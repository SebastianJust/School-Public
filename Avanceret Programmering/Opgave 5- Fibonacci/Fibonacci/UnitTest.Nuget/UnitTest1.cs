using System.Threading.Tasks;
using Fibonacci.Client;
using Fibonacci.Client.Models;
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
        public async Task NugetClient_Calculate_OK()
        {
            FibonacciHandler handler = new FibonacciHandler();

            ResponseModel result = await handler.Calculate(4000000);
            Assert.Pass();
        }
    }
}