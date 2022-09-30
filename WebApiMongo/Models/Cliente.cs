using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace WebApi.Models
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{get;set;}
        public string Nome {get;set;}
        public string Fantasia {get;set;}
        public string pfpj {get;set;}
    }
}