using System.Net;

namespace WhatsAppBusiness.Models.ClientModels
{
    public class ResponseDTO
    {
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Description { get; set; }
        //public IEnumerable<string> Description { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public object? Data { get; set; }
    }
}
