using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace privatemessagesender
{
    class Program
    {

        const string ServiceBusConnectionString = "";
        const string QueueName = "salesmessages";
        static IQueueClient queueClient;

        static void Main(string[] args)
        {
            Console.WriteLine("Sending a message to the Sales Messages queue...");

            SendSalesMessageAsync().GetAwaiter().GetResult();

            Console.WriteLine("Message was sent successfully.");
        }

        static async Task SendSalesMessageAsync()
        {
            // Create a Queue Client here

            // Send messages.
            try
            {
                // Create and send a message here
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }

            // Close the connection to the queue here
        }
    }
}
