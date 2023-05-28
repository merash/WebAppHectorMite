using AutoMapper;

namespace WebAPI.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Models.Request.Cliente, Models.Database.Cliente>();

            CreateMap<Models.Database.Cliente, Models.Response.Cliente>();

            CreateMap<Models.Response.Cliente, Models.Database.Cliente>();
        }
    }
}
