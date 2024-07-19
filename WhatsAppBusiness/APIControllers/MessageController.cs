using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using WhatsAppBusiness.Models;
using WhatsAppBusiness.Models.ClientModels;

namespace WhatsAppBusiness.APIControllers
{
    [Route("api/Message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IConfiguration _config;
        public MessageController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(MessageModel model)
        {
            string message = "";
            HttpResponseMessage response = new HttpResponseMessage();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_config.GetValue<string>("BaseUrls:WhatsAppApi"));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config.GetValue<string>("JwtTokens:WhatsApp"));
                response = await client.PostAsJsonAsync($"{model.PhoneId}/messages", model);
                var result = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    //return Ok(response);
                    message = "Message Successfully send";
                    return Ok(new APIResponse(true, false, message, HttpStatusCode.OK, null));
                }
            }
            message = "Error Encountered";
            return BadRequest(new APIResponse(true, true, message, HttpStatusCode.NotFound, null));

        }
    }
}
