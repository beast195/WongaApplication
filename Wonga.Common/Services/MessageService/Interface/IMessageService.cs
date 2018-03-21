using Wonga.Common.Models;

namespace Wonga.Common.Services.MessageService.Interface
{
    public interface IMessageService
    {
        void Initialise();

        void CreateQueue();

        void CreateConsumer();

        void SendMessage(MessageModel message);

        void Listen();
    }
}