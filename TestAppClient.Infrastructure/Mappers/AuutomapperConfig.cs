using AutoMapper;
using TestAppClient.Core.Domian;
using TestAppClient.Infrastructure.DTO;

namespace TestAppClient.Infrastructure.Mappers
{
    public class AuutomapperConfig
    {
        public static class AutoMapperConfig
        {
            public static IMapper Initialize()
                => new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Card, CardDto>();
                })
                .CreateMapper();
        }
    }
}
