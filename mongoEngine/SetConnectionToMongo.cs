using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace mongoEngine
{
    public interface IMongoInreface<T> where T : class
    {
        MongoClient setConnocetion();
        void InsertOne(T model,string collectionName);
    }

    public class MongoInterfaceClass<T> : IMongoInreface<T> where T : class
    {
 
        public void InsertOne(T model, string collectionName)
        {
            var db = setConnocetion().GetDatabase("tags");
            var collection = db.GetCollection<T>(collectionName);
            collection.InsertOne(model);

        }

        public MongoClient setConnocetion()
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                return client;
            }
            catch (Exception ex)
            {
                string er = ex.Message;
                var result = new MongoClient();
                return result;
            }
        }

    }
}
