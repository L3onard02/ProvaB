using punto1.DTOs;
using punto1.Entities;
using Punto1.DataSource;
using WebApiJWT.Helpers;

namespace punto1.Service
{
    public class ClienteService : IClienteService
    {
        private ProvaContext _context;
        private IJWTHelper _jwtHelper;
        public ClienteService(ProvaContext context, IJWTHelper jwtHelper)
        {
            _jwtHelper = jwtHelper;
            _context = context;
        }
        
        

        public async Task<string> loginCliente(Login c)
        {
            
            try
            {
                var query = from d in _context.Clienti
                            where d.Email == c.Email && d.Password == c.Password
                            select d;
                if (query.Count() != 1)
                {
                    string messaggioErrore = "login non effettuato";
                    //_logger.LogError("operazione non andata a buon fine");
                    throw new Exception(messaggioErrore);
                }
                var token= _jwtHelper.GeneraJSONWebToken();
                query.FirstOrDefault().token= token;
                query.FirstOrDefault().DataGenerazioneToken=DateTime.Now;

                return token;
             }
            catch (Exception ex)
            {
                throw;
            }
        }

        
    }
}
