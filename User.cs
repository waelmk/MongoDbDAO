using System;
using MongoDbGenericDao;

namespace MongoDbGenericDao
{
    public class User : MongoDBEntity
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
