using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace MongoDbGenericDao
{
    public interface IDao<T> where T : MongoDBEntity
    {       
        T Save(T pobject);
        
        T GetByID(object id);

        IList<T> SaveMany(IList<T> objects);

        long Count();
    }
}
