using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using System.Linq;

namespace MongoDbGenericDao
{
    public abstract class MongoDBGenericDao<T> : IDao<T> where T : MongoDBEntity
    {
        private MongoDatabase _repository;

        private readonly string _collectioname = typeof(T).Name;

        public MongoDBGenericDao(string pConnectionstring)
        {
            MongoClient client = new MongoClient(pConnectionstring);
            MongoServer server = client.GetServer();
            MongoUrl mongourl = MongoUrl.Create(pConnectionstring);
            _repository = server.GetDatabase(mongourl.DatabaseName);
        }

        public virtual T GetByID(object _id)
        {
            return _repository.GetCollection<T>(_collectioname).FindOne(Query.EQ("_id", new ObjectId(_id.ToString())));
        }

        public virtual T Save(T pobject)
        {
            _repository.GetCollection<T>(_collectioname).Save(pobject);
            return pobject;
        }

        public virtual IList<T> SaveMany(IList<T> objects)
        {
            _repository.GetCollection<T>(_collectioname).InsertBatch(objects);
            return objects;
        }

        public virtual long Count()
        {
            return _repository.GetCollection<T>(_collectioname).Count();
        }
    }
}
