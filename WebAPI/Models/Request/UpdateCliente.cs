namespace WebAPI.Models.Request
{
    public class UpdateCliente
    {
        public string Identificacion { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Correo { get; set; } = null!;
    }
}
