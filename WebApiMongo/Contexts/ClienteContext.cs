using MongoDB.Bson;
using MongoDB.Driver;
using WebApi.Models;

namespace WebApi.Contexts
{
    public class ClienteContext
    {
        private readonly IMongoCollection<Cliente> _cliente;

        public ClienteContext(IConfiguration config)
        {
            var mongo = new MongoClient(config.GetConnectionString("MongoDb"));
            var db = mongo.GetDatabase("Clientes");
            _cliente = db.GetCollection<Cliente>("Cliente");
        }

        public List<Cliente> Select()
        {
            return _cliente.Find(new BsonDocument()).ToList();
        }

        public Cliente Select(string Id)
        {
            return _cliente.Find(x => x.Id == Id).FirstOrDefault();
        }

        public Cliente Insert(Cliente cli)
        {
            _cliente.InsertOne(cli);
            return cli;
        }

        public void Update(string id, Cliente cli){
            _cliente.ReplaceOne(x=>x.Id == id, cli);
        }

        public void Delete(string id){
            _cliente.DeleteOne(x=>x.Id == id);
        }
        
    }
}