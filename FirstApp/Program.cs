using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    class Program
    {
        private static IQueueClient _queueClient;
        private const string ServiceBusConnectionString = "Endpoint=sb://sb-timetracker-dev.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Re6koaCjv7gkFJyUq6mBkmlPvG34PrbN+2MqpM9DWEY=";
        private const string QueueName = "follower-queue";

        static void Main(string[] args)
        {
            //UserFollowingInputModel inputModel = new UserFollowingInputModel("João", "Maria", "mail@mail.com");
            //string inputModelJsonString = JsonConvert.SerializeObject(inputModel);

            //var messagesBytes = Encoding.UTF8.GetBytes(inputModelJsonString);
            //var message = new Message(messagesBytes);

            MainAsync(args).GetAwaiter().GetResult();

        }

        private static async Task MainAsync(string[] args)
        {
            _queueClient = new QueueClient(ServiceBusConnectionString, QueueName, ReceiveMode.PeekLock);

            await SendMessagesToQueue(10);

            await _queueClient.CloseAsync();

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        //public static async void SendMessage(Message message)
        //{
        //    string busConnectionString = "Endpoint=sb://sb-timetracker-dev.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Re6koaCjv7gkFJyUq6mBkmlPvG34PrbN+2MqpM9DWEY=";
        //    string queueName = "follower-queue";

        //    QueueClient queueClient = new QueueClient(busConnectionString, queueName, ReceiveMode.PeekLock);

        //    await queueClient.SendAsync(message);

        //    await queueClient.CloseAsync();
        //}

        private static async Task SendMessagesToQueue(int numMessagesToSend)
        {
            for (var i = 0; i < numMessagesToSend; i++)
            {
                try
                {
                    // Create a new brokered message to send to the queue 
                    var message = new Message(Encoding.UTF8.GetBytes($"Message {i}"));

                    // Write the body of the message to the console 
                    Console.WriteLine($"Sending message: {Encoding.UTF8.GetString(message.Body)}");

                    // Send the message to the queue 
                    await _queueClient.SendAsync(message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
                }

                // Delay by 10 milliseconds so that the console can keep up 
                await Task.Delay(10);
            }

            Console.WriteLine($"{numMessagesToSend} messages sent.");
        }
    }
}
