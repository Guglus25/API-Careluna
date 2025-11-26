
using api_careluna.Models;

namespace api_careluna.Services.Clientes.Interfaces
{
    public interface IClientesServices
    {
        Task<List<ClientesModel>> ConsultarClientes();
        Task<ClientesModel> ConsultarClienteId(int id);
        Task<ClientesModel> GuardarCliente(ClientesModel data);
        Task<bool> EliminarCliente(int id);

    }
}