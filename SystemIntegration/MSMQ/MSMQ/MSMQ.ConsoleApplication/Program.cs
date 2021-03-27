using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSMQ.ConsoleApplication
{
    class Program
    {
        static Task Main(string[] args)
        {

            string privateQueue = @$"{ConfigurationManager.AppSettings["MSMQ_Private_Queue"]}";
            MessageQueue messageQueue = new MessageQueue(privateQueue);
            Console.WriteLine("******Waiting for messages******");
            while (true)
            {
                var message = messageQueue.Receive();
                if (message != null)
                {
                    Console.WriteLine($"Received id: {message.Id}");
                    messageQueue.GetMessageEnumerator2().RemoveCurrent();
                }
                Thread.Sleep(2000);

            }
        }
    }
}
