using InventaSINC.Objs.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace InventaSINC.Repositorios
{
    public abstract class RepositorioBase<TObj> where TObj : IIdentifiable
    {
        private MongoDBConnection _conect;

        public IMongoCollection<TObj> Collection { get; private set; }
        public abstract string NameCollection { get; set; }

        public RepositorioBase()
        {
            _conect = new MongoDBConnection();
            Collection = MongoDBConnection._database.GetCollection<TObj>(NameCollection);
        }
    }
}
