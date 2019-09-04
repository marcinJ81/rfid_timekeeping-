using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace mongoEngine
{
    public interface IConnectMongoClient
    {
        MongoClient setConnocetion();
        
    }

    public class ConnectMongoClient : IConnectMongoClient
    {
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
