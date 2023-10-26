using Microsoft.AspNetCore.Mvc;
using Mongo.Entities;
using Mongo.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrelloController : ControllerBase
    {

        private readonly ICarrelloService _service;
            public CarrelloController(ICarrelloService service)
        {
            _service=service;   
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carrello>> Get(int id)
        {
            try
            {
                return await _service.GetCarrello(id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task Post([FromBody] Carrello c)
        {
            
            
                await _service.CreateCarrello(c);
           

        }

        

       
    }
}
