using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Entities
{
    public class Carrello
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int IdentificativoCarrello { get; set; }
        public int IdentificativoCliente { get; set; }
        public int ProdottoIdentificativoProdotto { get; set; }
        public int Quantità { get; set; }
        public double Prezzo { get; set; }
    }
}
