using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace privatemessagereceiver
{
    class Program
    {

        const string ServiceBusConnectionString = "";
        const string QueueName = "salesmessages";

        static void Main(string[] args)
        {

            ReceiveSalesMessageAsync().GetAwaiter().GetResult();

        }

        static async Task ReceiveSalesMessageAsync()
        {

            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to exit after receiving all the messages.");
            Console.WriteLine("======================================================");


            // Create a ServiceBus Client that will authenticate using a connection string

            // Create the options to use for configuring the processor

            // Create a processor that we can use to process the messages

            // Configure the message and error handler to use

            Console.Read();

            // Close the processor here

        }

        static async Task ProcessMessagesAsync(ProcessMessageEventArgs message)
        {
            throw new NotImplementedException();
        }

        static Task ExceptionReceivedHandler(ProcessErrorEventArgs err)
        {
            Console.WriteLine($"Message handler encountered an exception {err.Exception}.");
            Console.WriteLine("Exception context for troubleshooting:");
            Console.WriteLine($"- Endpoint: {err.FullyQualifiedNamespace}");
            Console.WriteLine($"- Entity Path: {err.EntityPath}");
            Console.WriteLine($"- Executing Action: {err.ErrorSource}");
            return Task.CompletedTask;
        }   
    }
}
