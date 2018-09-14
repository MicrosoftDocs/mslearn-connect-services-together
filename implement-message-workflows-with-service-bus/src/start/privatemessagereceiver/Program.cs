using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace privatemessagereceiver
{
    class Program
    {

        const string ServiceBusConnectionString = "";
        const string QueueName = "salesmessages";
        static IQueueClient queueClient;

        static void Main(string[] args)
        {

            ReceiveSalesMessageAsync().GetAwaiter().GetResult();

        }

        static async Task ReceiveSalesMessageAsync()
        {

            // Create a Queue Client here

            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to exit after receiving all the messages.");
            Console.WriteLine("======================================================");

            RegisterMessageHandler();
        
            Console.Read();

            // Close the queue here

        }

        static void RegisterMessageHandler()
        {
            throw new NotImplementedException();
        }

        static async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            Console.WriteLine("Exception context for troubleshooting:");
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Executing Action: {context.Action}");
            return Task.CompletedTask;
        }   
    }
}
