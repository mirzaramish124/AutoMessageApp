using Newtonsoft.Json;
using System.Net;
using System.Text;
using WhatsAppBusiness.Models.ClientModels;
using WhatsAppBusiness.Services.ClientService.IServices;
using static WhatsAppBusiness.Utility.SD;

namespace WhatsAppBusiness.Services.ClientService.Services
{
    public class ClientService : IClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDTO> SendAsync(RequestDto requestDto, bool withBearer = false)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("ECom");
                HttpRequestMessage httpRequest = new();
                httpRequest.Headers.Add("accept", "application/json");
                if (withBearer)
                {
                    //httpRequest.Headers.Add("Authorization",$"Bearer{token}");
                }
                httpRequest.RequestUri = new Uri(requestDto.Url);
                if (requestDto.Data != null)
                {
                    httpRequest.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }
                switch (requestDto.APIType)
                {
                    case APITypes.Get:
                        httpRequest.Method = HttpMethod.Get;
                        break;
                    case APITypes.Post:
                        httpRequest.Method = HttpMethod.Post;
                        break;
                    case APITypes.Put:
                        httpRequest.Method = HttpMethod.Put;
                        break;
                    case APITypes.Delete:
                        httpRequest.Method = HttpMethod.Delete;
                        break;
                    default:
                        httpRequest.Method = HttpMethod.Get;
                        break;
                }
                HttpResponseMessage httpResponse = await client.SendAsync(httpRequest);
                string? apiContent = await httpResponse.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                switch (httpResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { Error = true, Success = false, Description = apiResponse?.Description, StatusCode = HttpStatusCode.NotFound };
                    case HttpStatusCode.Forbidden:
                        return new() { Error = true, Success = false, Description = apiResponse?.Description, StatusCode = HttpStatusCode.Forbidden };
                    case HttpStatusCode.Unauthorized:
                        return new() { Error = true, Success = false, Description = apiResponse?.Description, StatusCode = HttpStatusCode.Unauthorized };
                    case HttpStatusCode.BadRequest:
                        return new() { Error = true, Success = false, Description = apiResponse?.Description, StatusCode = HttpStatusCode.BadRequest };
                    default:
                        return apiResponse;
                }
            }
            catch (Exception ex)
            {
                return new()
                {
                    Description = ex.Message,
                    Success = false,
                    Error = true
                };
            }
        }
    }
}
