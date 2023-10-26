using Mongo.Entities;

namespace Mongo.Service
{
    public interface ICarrelloService
    {
        Task<Carrello> GetCarrello(int id);

        Task CreateCarrello(Carrello product);
    }
}
