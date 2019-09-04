using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using System;

namespace mongoEngine
{
    
    public interface IMongoInreface<T> where T : class
    {
        void InsertOne(T model, IMongo_List mongoList);
        void FindAndUpdate(T model, string valueForUpdate, IMongo_List mongoListe);
    }
    public class MongoInterfaceClass<T> : IMongoInreface<T> where T : class
    {
        private IMongoDatabase db { get; set; }
        private IMongoCollection<T> collectionDB { get; set; }
        private IConnectMongoClient imongoCon { get; set; }
        public MongoInterfaceClass()
        {
            imongoCon = new ConnectMongoClient();
        }
        public void InsertOne(T model, IMongo_List imongoList)
        {
             db = imongoCon.setConnocetion().GetDatabase(imongoList.getSpecificParamters("test_mongo").base_name);
             collectionDB = db.GetCollection<T>(imongoList.getSpecificParamters("test_mongo").collection_name);
             collectionDB.InsertOne(model);
        }

        //tymczasowe rozwiązanie (temporary solution, break the method)
        public void FindAndUpdate(T model, string valueForUpdate, IMongo_List mongoList)
        {
           
        }
    }
}
