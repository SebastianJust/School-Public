using System.Threading.Tasks;
using Fibonacci.Client;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace UnitTest
{
    public class Tests
    {


        public void Setup()
        {
        }


        [Test]
        public async Task Client_Calculate_OK()
        {
            var handler = new FibonacciHandler();
            
            var result = await handler.Calculate(10);
            Assert.Pass();
        }
    }
}