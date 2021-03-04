using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Text;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UserFollowingInputModel inputModel = new UserFollowingInputModel(1, 1, "mail@mail.com");
            string inputModelJsonString = JsonConvert.SerializeObject(inputModel);

            var messagesBytes = Encoding.UTF8.GetBytes(inputModelJsonString);
            var message = new Message(messagesBytes);

            SendMessage(message);
        }

        public static async void SendMessage(Message message)
        {
            string busConnectionString = "";
            string queueName = "example-queue";

            QueueClient queueClient = new QueueClient(busConnectionString, queueName);

            await queueClient.SendAsync(message);
        }
    }
}
