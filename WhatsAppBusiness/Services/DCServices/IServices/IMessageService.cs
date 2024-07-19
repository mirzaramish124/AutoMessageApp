using WhatsAppBusiness.Models;

namespace WhatsAppBusiness.Services.DCServices.IServices
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageModel>> SendMessage(MessageModel model);
    }
}
