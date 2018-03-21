using System;
using Unity;
using Unity.Lifetime;
using Wonga.Common.DependencyInjection;
using Wonga.Common.Services.MessageService.Interface;

namespace Wonga.Receiver
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello there!");
            Console.WriteLine("Waiting for messages ... ");

            var container = new UnityContainer();
            DIContainerHelper.RegisterComponents<HierarchicalLifetimeManager>(container);

            var messageService = container.Resolve<IMessageService>();
            messageService.CreateQueue();
            messageService.CreateConsumer();
            messageService.Listen();
        }
    }
}