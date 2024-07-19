using AutoMapper;
using WhatsAppBusiness;
using WhatsAppBusiness.Models;

namespace ECommerceSiteWithAPIs.Utility
{
    public class MappingConfig
    {
        public static MapperConfiguration Registermaps()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                //config.CreateMap<Brand,BrandDto>().ReverseMap();
            });
            return mapperConfig;
        }
    }
}
