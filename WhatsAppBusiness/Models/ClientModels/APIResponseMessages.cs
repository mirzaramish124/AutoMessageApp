using System.Net;

namespace WhatsAppBusiness.Models.ClientModels
{
    public class APIResponse
    {
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Description { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public object? Data { get; set; }

        public APIResponse(bool success, bool error, string msg, HttpStatusCode statusCode, object? data)
        {
            Success = success;
            Error = error;
            Description = msg;
            StatusCode = statusCode;
            Data = data;
        }
    }

}
