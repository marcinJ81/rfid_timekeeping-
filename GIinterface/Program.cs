using DB_repository;
using MongoDB.Bson;
using MongoDB.Driver;
using mongoEngine;
using System;
using System.Collections.Generic;
using System.Linq;
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

            

            //DB_repository.Tag tag = new DB_repository.Tag()
            //{
            //    Id = ObjectId.GenerateNewId().ToString(),
            //    Tag_id = igenId.generateTagId(),
            //    Tag_label = igenId.generateLabel(),
            //    Tag_time = DateTime.Now.ToUniversalTime()
            //};

            //itag.addData(tag);
            //imongointerface.InsertOne(itag.getData());

            //var documents = imongointerface.GetAllDocumentsFromCollection();
            //foreach (var i in documents)
            //{
            //    Console.WriteLine(i.Id + " " + i.Tag_id + " " + i.Tag_label + " " + i.Tag_time.ToLongTimeString());
            //}

            //FilterDefinition<DB_repository.Tag> filter = Builders<DB_repository.Tag>.Filter.Eq("tag_label", "25");
            //UpdateDefinition<DB_repository.Tag> source = Builders<DB_repository.Tag>.Update.Set("tag_id", igenId.generateTagId());
            //imongointerface.UpdateOne(filter,source);

            //Console.WriteLine("\r");

            //var documents2 = imongointerface.GetAllDocumentsFromCollection();
            //documents2 = documents2.Where(x => x.Tag_label == "25").ToList();
            //Console.WriteLine(documents2[0].Id + " " + documents2[0].Tag_id + " " + documents2[0].Tag_label + " " + documents2[0].Tag_time.ToLongTimeString() );

        }

    }
}
