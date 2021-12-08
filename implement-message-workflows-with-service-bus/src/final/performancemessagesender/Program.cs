using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace performancemessagesender
{    
    class Program
    {
        const string ServiceBusConnectionString = "";
        const string TopicName = "salesperformancemessages";
        private static ServiceBusClient s_client;
        private static ServiceBusSender s_sender;

        static void Main(string[] args)
        {

            Console.WriteLine("Sending a message to the Sales Performance topic...");

            SendPerformanceMessageAsync().GetAwaiter().GetResult();

            Console.WriteLine("Message was sent successfully.");

        }

        static async Task SendPerformanceMessageAsync()
        {
            s_client = new ServiceBusClient(ServiceBusConnectionString);
            // Send messages.
            try
            {
                string messageBody = $"Total sales for Brazil in August: $13m.";
                 s_sender = s_client.CreateSender(TopicName);
                 ServiceBusMessage message = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody));

                // Write the body of the message to the console.
                Console.WriteLine($"Sending message: {messageBody}");

                // Send the message to the queue.
                await s_sender.SendMessageAsync(message);

            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }

            await s_sender.CloseAsync();
            Console.WriteLine("Disposing client");
            await s_client.DisposeAsync();
        }
    }
}
