using EasyNetQ;
using Newtonsoft.Json;
using RabbitMqDemo.Messages;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace RabbitMqDemo.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = RabbitHutch.CreateBus("amqp://hzlywamn:L0FaWRquJYSOa1yBiEcVfSX-WAuUdE4Z@crane.rmq.cloudamqp.com/hzlywamn");

            bus.SubscribeAsync<UserCreated>(Assembly.GetExecutingAssembly().GetName().Name, userCreated =>
            {
                Console.WriteLine($"Message received: {JsonConvert.SerializeObject(userCreated)}");
                return Task.CompletedTask;

            }, configuration =>
            {
                configuration.WithDurable();
            });

            Console.ReadKey();
        }
    }
}
