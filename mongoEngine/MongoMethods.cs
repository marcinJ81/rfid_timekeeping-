using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using System;
using System.Collections.Generic;

namespace mongoEngine
{
    
    public interface IMongoInreface<T> where T : class
    {
        void InsertOne(T model);
        void UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> source);
        List<T> GetAllDocumentsFromCollection();
        T GEtSpecificDocument(FilterDefinition<T> filter);
        void DeleteOne(FilterDefinition<T> filter);

    }
    public class MongoInterfaceClass<T> : IMongoInreface<T> where T : class, new()
    {
      
        private IMongoDatabase db { get; set; }
        private IMongoCollection<T> collectionDB { get; set; }
        private IConnectMongoClient imongoCon { get; set; }
        private IMongo_List imongoList { get; set; }

        public MongoInterfaceClass()
        {
            imongoList = new MongoDB_List();
            imongoCon = new ConnectMongoClient();
            db = imongoCon.setConnocetion().GetDatabase(imongoList.getSpecificParamters("test_mongo").base_name);
            collectionDB = db.GetCollection<T>(imongoList.getSpecificParamters("test_mongo").collection_name);  
        }

        public MongoInterfaceClass(IMongoDatabase db, IMongoCollection<T> collectionDB, IConnectMongoClient imongoCon, IMongo_List imongoList)
        {
            this.imongoList = imongoList;
            this.imongoCon = imongoCon;
            this.db = db;
            this.collectionDB = collectionDB;
        }
        public void InsertOne(T model)
        {
             collectionDB.InsertOne(model);
        }
        public void UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> source)
        {
            collectionDB.UpdateOne(filter,source);
        }
        public List<T> GetAllDocumentsFromCollection()
        {
            var filter = Builders<T>.Filter.Empty;
            var documents = collectionDB.Find(filter).ToList();
            return documents;
        }

        public T GEtSpecificDocument(FilterDefinition<T> filter)
        {
            return collectionDB.Find(filter).First();
        }

        public void DeleteOne(FilterDefinition<T> filter)
        {
            collectionDB.DeleteOne(filter);
        }
    }
}
