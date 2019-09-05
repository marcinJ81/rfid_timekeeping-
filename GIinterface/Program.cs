using DB_repository;
using MongoDB.Bson;
using MongoDB.Driver;
using mongoEngine;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GIinterface
{
    class Program
    {
        private static IMongoInreface<DB_repository.Tag> imongointerface { get; set; }
        private static ITag_Services<DB_repository.Tag> itag { get; set; }

        static void Main(string[] args)
        {
            IMongo_List ilistDB = new MongoDB_List();
            IConnectMongoClient imongoCon = new ConnectMongoClient();
            imongointerface = new MongoInterfaceClass<DB_repository.Tag>();
            IGeneratorId igenId = new GenerateId();
            itag = new Tag_services();
            IMongoDatabase db = imongoCon.setConnocetion().GetDatabase(ilistDB.getSpecificParamters("test_mongo").base_name);
            IMongoCollection<DB_repository.Tag> dbCollection = db.GetCollection<DB_repository.Tag>(ilistDB.getSpecificParamters("test_mongo").collection_name);

            //var filter = Builders<DB_repository.Tag>.Filter.Empty;
            //var documents = dbCollection.Find(filter).ToList();
            //foreach (var i in documents)
            //{
            //    Console.WriteLine(i);
            //}

            //var document1 = dbCollection.Find(new BsonDocument()).FirstOrDefault();
            //Console.WriteLine(document1.ToString());

            DB_repository.Tag tag = new DB_repository.Tag()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Tag_id = igenId.generateTagId(),
                Tag_label = igenId.generateLabel(),
                Tag_time = DateTime.Now.ToUniversalTime() 
            };


            itag.addData(tag);
            imongointerface.InsertOne(itag.getData(), ilistDB);


        }

    }
}
