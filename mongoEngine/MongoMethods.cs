﻿using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using System;
using System.Collections.Generic;

namespace mongoEngine
{
    
    public interface IMongoInreface<T> where T : class
    {
        void InsertOne(T model);
        void FindAndUpdate(T model, string valueForUpdate);
        List<T> GetAllDocumentsFromCollection();
    }
    public class MongoInterfaceClass<T> : IMongoInreface<T> where T : class
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
        public void InsertOne(T model)
        {
             collectionDB.InsertOne(model);
        }
        public void FindAndUpdate(T model, string valueForUpdate)
        {
            db = imongoCon.setConnocetion().GetDatabase(imongoList.getSpecificParamters("test_mongo").base_name);
            collectionDB = db.GetCollection<T>(imongoList.getSpecificParamters("test_mongo").collection_name);
            //collectionDB.FindOneAndUpdate(model,)

        }
        public List<T> GetAllDocumentsFromCollection()
        {
            var filter = Builders<T>.Filter.Empty;
            var documents = collectionDB.Find(filter).ToList();
            return documents;
        }
    }
}
