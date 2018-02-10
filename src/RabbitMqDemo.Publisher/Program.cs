using EasyNetQ;
using Newtonsoft.Json;
using RabbitMqDemo.Messages;
using System;
using System.Threading.Tasks;

namespace RabbitMqDemo.Publisher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var bus = RabbitHutch.CreateBus("amqp://hzlywamn:L0FaWRquJYSOa1yBiEcVfSX-WAuUdE4Z@crane.rmq.cloudamqp.com/hzlywamn");

            for (int i = 0; i < 100; i++)
            {
                var name = Faker.NameFaker.FirstName();
                var username = $"{name}_user_{i}";

                var message = new UserCreated
                {
                    Username = username,
                    Name = name,
                    Email = Faker.InternetFaker.Email()
                };

                await bus.PublishAsync(message);

                Console.WriteLine($"Message published: {JsonConvert.SerializeObject(message)}");
            }
            
            Console.ReadKey();
        }
    }
}
