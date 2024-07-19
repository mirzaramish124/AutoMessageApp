using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Unicode;
using WhatsAppBusiness.Models;
using WhatsAppBusiness.Services.DCServices.IServices;

namespace WhatsAppBusiness.Controllers
{
    public class MessageController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IMessageService _messageService;
        public MessageController(IConfiguration config, IMessageService messageService)
        {
            _config = config;
            _messageService = messageService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new MessageModel()
            {
                PhoneId = "362684750265305",
                messaging_product = "whatsapp",
                to = "+923020640249",
                type = "template",
                template = new Template()
                {
                    name = "hello_world",
                    language = new Language()
                    {
                        code = "en_US"
                    }
                },
            };
            var response = _messageService.SendMessage(model);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(MessageModel model)
        {
            //model = new MessageModel()
            //{
            //    PhoneId = "362684750265305",
            //    messaging_product = "whatsapp",
            //    to = "+923020640249",
            //    type = "template",
            //    template = new Template()
            //    {
            //        name = "hello_world",
            //        language = new Language()
            //        {
            //            code = "en_US"
            //        }
            //    },
            //};
            //var content = new StringContent(model.ToString(), Encoding.UTF8, "application/json");
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(_config.GetValue<string>("BaseUrls:ApiUrl"));
            //    var response = await client.PostAsJsonAsync("api/Message/SendMessage", model);
            //}
            return View();
        }
    }
}
