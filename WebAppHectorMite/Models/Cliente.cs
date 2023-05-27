namespace WebAppHectorMite.Models
{
    public class Cliente
    {
        public long IdCliente { get; set; }

        public string Identificacion { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Correo { get; set; } = null!;
    }
}
