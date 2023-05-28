using AutoMapper;

namespace WebAPI.Profiles
{
    public class ProductoProfile: Profile
    {
        public ProductoProfile()
        {
            CreateMap<Models.Response.Producto, Models.Database.Producto>();

            CreateMap<Models.Database.Producto, Models.Response.Producto>();
        }
    }
}
