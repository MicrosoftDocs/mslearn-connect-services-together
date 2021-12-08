using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace performancemessagereceiver
{
    class Program
    {
        const string ServiceBusConnectionString = "";
        const string TopicName = "salesperformancemessages";
        const string SubscriptionName = "Americas";
        private static ServiceBusClient s_client;

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
             s_client = new ServiceBusClient(ServiceBusConnectionString);

            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to exit after receiving all the messages.");
            Console.WriteLine("======================================================");

             


            await ReceiveMessagesAsync(SubscriptionName);

            Console.Read();
             Console.WriteLine("=======================================================================");
            Console.WriteLine("Completed Receiving all messages. Disposing clients and deleting topic.");
            Console.WriteLine("=======================================================================");

            
            Console.WriteLine("Disposing client");
            await s_client.DisposeAsync();
        }
        private static async Task ReceiveMessagesAsync(string subscriptionName)
        {
            await using ServiceBusReceiver subscriptionReceiver = s_client.CreateReceiver(
                TopicName,
                subscriptionName,
                new ServiceBusReceiverOptions { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete });

            Console.WriteLine($"==========================================================================");
            Console.WriteLine($"{DateTime.Now} :: Receiving Messages From Subscription: {subscriptionName}");
            int receivedMessageCount = 0;
            while (true)
            {
                var receivedMessage = await subscriptionReceiver.ReceiveMessageAsync(TimeSpan.FromSeconds(1));
                if (receivedMessage != null)
                {
                    Console.WriteLine($"Received sale performance message: SequenceNumber:{receivedMessage.SequenceNumber} Body:{Encoding.UTF8.GetString(receivedMessage.Body)}");

                    receivedMessageCount++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"{DateTime.Now} :: Received '{receivedMessageCount}' Messages From Subscription: {subscriptionName}");
            Console.WriteLine($"==========================================================================");
            await subscriptionReceiver.CloseAsync();
        }
          
    }
}
