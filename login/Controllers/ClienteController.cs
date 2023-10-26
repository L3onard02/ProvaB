using Microsoft.AspNetCore.Mvc;
using punto1.DTOs;
using punto1.Entities;
using punto1.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace punto1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private IClienteService _service;
        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] Login c)
        {
            
            try
            {
                
                return await _service.loginCliente(c);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
