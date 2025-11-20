namespace api_careluna.Services.Clientes.Implementations
{
    public class ClientesServices : IClientesServices
    {
        private readonly AppDbContext _context;

        public ClientesServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClientesModel>> ConsultarClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<ClientesModel> ConsultarClienteId(int id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(p => p.cli_Id == id);
        }
        public async Task<ClientesModel> GuardarCliente(ClientesModel data)
        {
            _context.Clientes.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> EliminarCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefaultAsync(p => p.cli_Id == id);
            if (cliente == null) return false;

            cliente.cli_Estado = "I";
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();

            return true;
        }



    }
}