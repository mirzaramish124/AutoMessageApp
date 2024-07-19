using static WhatsAppBusiness.Utility.SD;

namespace WhatsAppBusiness.Models.ClientModels
{
    public class RequestDto
    {
        public APITypes APIType { get; set; } = APITypes.Get;
        public string Url { get; set; }
        public object? Data { get; set; }
    }
}
