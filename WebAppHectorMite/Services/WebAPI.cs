using WebAppHectorMite.Models;

namespace WebAppHectorMite.Services
{
    public class WebAPI : IWebAPI
    {
        private readonly HttpClient httpClient;

        public WebAPI(HttpClient httpClient) => this.httpClient = httpClient;

        public List<Cliente>? GetClientes()
        {
            return httpClient.GetFromJsonAsync<List<Cliente>>(httpClient.BaseAddress + "Cliente")?.Result?.ToList();
        }

        public Cliente? GetCliente(long IdCliente)
        {
            return httpClient.GetFromJsonAsync<Cliente>(httpClient.BaseAddress + "Cliente/" + IdCliente)?.Result;
        }

        public Cliente? CreateCliente(Cliente cliente)
        {
            return httpClient.PostAsJsonAsync(httpClient.BaseAddress + "Cliente", cliente)?.Result?.Content?.ReadFromJsonAsync<Cliente>().Result;
        }

        public Cliente? UpdateCliente(Cliente cliente)
        {
            return httpClient.PutAsJsonAsync(httpClient.BaseAddress + "Cliente/" + cliente.IdCliente, cliente)?.Result?.Content?.ReadFromJsonAsync<Cliente>().Result;
        }

        public List<Producto>? GetProductos()
        {
            return httpClient.GetFromJsonAsync<List<Producto>>(httpClient.BaseAddress + "Producto")?.Result?.ToList();
        }

        public Producto? GetProducto(long IdProducto)
        {
            return httpClient.GetFromJsonAsync<Producto>(httpClient.BaseAddress + "Producto/" + IdProducto)?.Result;
        }

        public Producto? CreateProducto(Producto producto)
        {
            return httpClient.PostAsJsonAsync(httpClient.BaseAddress + "Producto", producto)?.Result?.Content?.ReadFromJsonAsync<Producto>().Result;
        }

        public Producto? UpdateProducto(Producto producto)
        {
            return httpClient.PutAsJsonAsync(httpClient.BaseAddress + "Producto/" + producto.IdProducto, producto)?.Result?.Content?.ReadFromJsonAsync<Producto>().Result;
        }

        public List<Factura>? GetFacturas()
        {
            return httpClient.GetFromJsonAsync<List<Factura>>(httpClient.BaseAddress + "Factura")?.Result?.ToList();
        }

        public Factura? GetFactura(long IdFactura)
        {
            return httpClient.GetFromJsonAsync<Factura>(httpClient.BaseAddress + "Factura/" + IdFactura)?.Result;
        }

        public Factura? CreateFactura(Factura factura)
        {
            return httpClient.PostAsJsonAsync(httpClient.BaseAddress + "Factura", factura)?.Result?.Content?.ReadFromJsonAsync<Factura>().Result;
        }
    }
}
