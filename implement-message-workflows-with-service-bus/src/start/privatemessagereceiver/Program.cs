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


            // Create a Service Bus client that will authenticate using a connection string

            // Create the options to use for configuring the processor

            // Create a processor that we can use to process the messages

            // Configure the message and error handler to use

            // Start processing

            Console.Read();

            // Close the processor here

        }

        // handle received messages
        static async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            Console.WriteLine($"Received: {body}");

            // complete the message. messages is deleted from the queue. 
            await args.CompleteMessageAsync(args.Message);
        }

        // handle any errors when receiving messages
        static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }
    }
}
