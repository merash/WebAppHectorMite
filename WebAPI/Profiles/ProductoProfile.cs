using AutoMapper;

namespace WebAPI.Profiles
{
    public class ProductoProfile: Profile
    {
        public ProductoProfile()
        {
            CreateMap<Models.Request.Producto, Models.Database.Producto>();

            CreateMap<Models.Database.Producto, Models.Response.Producto>();

            CreateMap<Models.Response.Producto, Models.Database.Producto>();
        }
    }
}
