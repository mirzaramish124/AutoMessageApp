using WhatsAppBusiness.Models.ClientModels;

namespace WhatsAppBusiness.Services.ClientService.IServices
{
    public interface IClientService
    {
        Task<ResponseDTO> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
