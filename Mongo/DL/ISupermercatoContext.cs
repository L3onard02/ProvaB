using Mongo.Entities;
using MongoDB.Driver;

namespace Mongo.DL
{
    public interface ISupermercatoContext
    {
        IMongoCollection<Carrello> Carrelli {  get; }
    }
}
