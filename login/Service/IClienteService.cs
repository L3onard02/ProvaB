using punto1.DTOs;
using punto1.Entities;

namespace punto1.Service
{
    public interface IClienteService
    {
        Task<string> loginCliente(Login c);
      
    }
}
