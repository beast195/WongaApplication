﻿using System;
using Unity;
using Unity.Lifetime;
using Wonga.Common.DependencyInjection;
using Wonga.Common.Models;
using Wonga.Common.Services.MessageService.Interface;

namespace Wonga.Broadcaster
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello there!");
            Console.WriteLine("Help \n  - To Exit type 'exit' \n\n");
            var container = new UnityContainer();
            DIContainerHelper.RegisterComponents<HierarchicalLifetimeManager>(container);
            var messageService = container.Resolve<IMessageService>();
            messageService.CreateQueue();
            GetUserInput(messageService);
        }

        private static void GetUserInput(IMessageService service)
        {
            Console.WriteLine("Compose a message ... ");
            var userInput = Console.ReadLine();
            if (!userInput.Contains("exit"))
            {
                var message = new MessageModel
                {
                    Id = Guid.NewGuid(),
                    MessageBody = userInput,
                    Sender = "WongaBroadcaster",
                    SentAt = DateTime.Now
                };
                service.SendMessage(message);
                GetUserInput(service);
            }
        }
    }
}