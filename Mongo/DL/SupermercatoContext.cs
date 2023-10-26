using Microsoft.Extensions.Options;
using Mongo.Entities;
using Mongo.Model;
using MongoDB.Driver;

namespace Mongo.DL
{
    public class SupermercatoContext : ISupermercatoContext
    {
        DatabaseSettings _settings;
        public SupermercatoContext(IOptions<DatabaseSettings> DatabaseSettings)
        {
            var client = new MongoClient(DatabaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(DatabaseSettings.Value.DatabaseName);
            Carrelli = database.GetCollection<Carrello>(DatabaseSettings.Value.CollectionName);

        }
        public IMongoCollection<Carrello> Carrelli { get; }
    }
}
