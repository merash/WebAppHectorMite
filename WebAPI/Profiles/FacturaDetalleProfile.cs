using AutoMapper;

namespace WebAPI.Profiles
{
    public class FacturaDetalleProfile : Profile
    {
        public FacturaDetalleProfile()
        {
            CreateMap<Models.Request.FacturaDetalle, Models.Database.FacturaDetalle>();
        }
    }
}
