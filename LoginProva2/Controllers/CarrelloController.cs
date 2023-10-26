using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using WebApiProvaFaseA.Entities;
using WebApiProvaFaseA.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiProvaFaseA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrelloController : ControllerBase
    {
        private ICarrelloService _service;
        public CarrelloController(ICarrelloService service)
        {
            _service = service;
        }

        // GET api/<CarrelloController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrello>>Get(int id)
        {
            if (id < 1) return NotFound("id minore a 1");

            try
            {
                string auth = Request.Headers[HeaderNames.Authorization];
                if (!string.IsNullOrWhiteSpace(auth))
                {
                    var token = auth.Split(" ")[1];
                    if (token == "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2OTgyMzE1NDQsImlzcyI6Ik5TMTIuaXQiLCJhdWQiOiJOUzEyLml0In0.-PCdGz4xJOHMK9kfKEAqZ_aie1g2P0dbCBF_a7aFPGE")
                    {
                        var lista = await _service.GetFromId(id);
                        return lista;
                    }
                    else return Unauthorized();
                }
                return NotFound();

                

            }
            catch (Exception ex)
            {

                return Problem("Al momento non è possibile soddisfare la richiesta");
            }
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Carrello c)
        {
            if (id < 1) return NotFound("id minore a 1");

            int numeroRecord = 0;

            try
            {
                string auth = Request.Headers[HeaderNames.Authorization];
                if (!string.IsNullOrWhiteSpace(auth))
                {
                    var token = auth.Split(" ")[1];
                    if (token == "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2OTgyMzE1NDQsImlzcyI6Ik5TMTIuaXQiLCJhdWQiOiJOUzEyLml0In0.-PCdGz4xJOHMK9kfKEAqZ_aie1g2P0dbCBF_a7aFPGE")
                    {
                        numeroRecord = await _service.Update(c, id);
                        return Ok();
                    }
                    else return Unauthorized();
                }
                return NotFound();



                
            }
            catch (Exception ex)
            {
                if (numeroRecord != 1)
                {
                    return Problem("Operazione non effettuata");
                }
                else
                {
                    return Problem("Problemi di connessione");

                }

            }
        }

       
    }
}
