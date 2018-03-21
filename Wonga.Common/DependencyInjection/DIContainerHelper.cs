using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.IO;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Wonga.Common.Services.ConsoleWrapper;
using Wonga.Common.Services.ConsoleWrapper.Interface;
using Wonga.Common.Services.MessageService;
using Wonga.Common.Services.MessageService.Interface;

namespace Wonga.Common.DependencyInjection
{
    public static class DIContainerHelper
    {
        public static void RegisterComponents<T>(UnityContainer container) where T : LifetimeManager, new()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();
            container.RegisterType<IConsole, ConsoleWrapper>(new T());
            container.RegisterType<IMessageService, MessageService>(new T());
            container.RegisterType<IConfigurationRoot>(new T(), new InjectionFactory(c =>
            {
                return configuration;
            }));
            container.RegisterType<ConnectionFactory>(new T(), new InjectionFactory(c =>
            {
                return new ConnectionFactory
                {
                    UserName = configuration["Username"],
                    Password = configuration["Password"],
                    HostName = configuration["Host"],
                    VirtualHost = configuration["VHost"]
                };
            }));
        }
    }
}