using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WhatsAppBusiness.Models;
using WhatsAppBusiness.Models.ClientModels;
using WhatsAppBusiness.Services.ClientService.IServices;
using WhatsAppBusiness.Services.DCServices.IServices;
using static WhatsAppBusiness.Utility.SD;

namespace WhatsAppBusiness.Services.DCServices.Services
{
    public class MessageService : IMessageService
    {
        private readonly IClientService _clientService;
        //private readonly IConfiguration _config;
        private string APIBaseUrl { get; set; }
        public MessageService(IClientService clientService, IConfiguration config)
        {
            _clientService = clientService;
            APIBaseUrl = config.GetValue<string>("BaseUrls:ApiUrl");
        }

        public async Task<IEnumerable<MessageModel>> SendMessage(MessageModel model)
        {
            List<MessageModel>? objList = new();
            ResponseDTO response = await _clientService.SendAsync(new()
            {
                APIType = APITypes.Post,
                Url = $"{APIBaseUrl}api/Message/SendMessage",
                Data = model
            });
            if (response.Data != null && response.Success)
            {
                objList = JsonConvert.DeserializeObject<List<MessageModel>>(Convert.ToString(response.Data));
            }
            return objList;
        }
    }
}
