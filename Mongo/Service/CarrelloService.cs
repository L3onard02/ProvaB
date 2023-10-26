using Mongo.DL;
using Mongo.Entities;
using MongoDB.Driver;

namespace Mongo.Service
{
    public class CarrelloService : ICarrelloService
    {
        private readonly ISupermercatoContext _context;
        public CarrelloService(ISupermercatoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async  Task CreateCarrello(Carrello product)
        {
            await _context.Carrelli.InsertOneAsync(product);

        }

        public async Task<Carrello> GetCarrello(int id)
        {
            return await _context
                          .Carrelli
                          .Find(p => p.IdentificativoCliente == id)
                          .FirstOrDefaultAsync();
        }
    }
}
