using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace mongoEngine
{
    public interface IMongoConnection
    {
        MongoClient setConnocetion();
    }

    public class MongoConnection : IMongoConnection
    {
        public MongoClient setConnocetion()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            return client;
        }
    }
}
