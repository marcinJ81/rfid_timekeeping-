using DB_repository;
using MongoDB.Bson;
using MongoDB.Driver;
using mongoEngine;
using System;
using System.Threading.Tasks;

namespace GIinterface
{
    class Program
    {
        private static IMongoConnection imongoCon { get; set; }
        private static ITag_Services<DB_repository.Tag> itag { get; set; }

        static void Main(string[] args)
        {
            imongoCon = new MongoConnection();
            itag = new Tag_services();
            string collectionName = "test";
            var database = imongoCon.setConnocetion().GetDatabase("tags");
            var collection = database.GetCollection<DB_repository.Tag>(collectionName);

            var model = itag.getEmptyModel();
            collection.InsertOne(model);
           // Console.WriteLine("Hello World!");
        }
        static async Task MainAsync()
        {
            //https://www.codementor.io/pmbanugo/working-with-mongodb-in-net-1-basics-g4frivcvz
            var client = new MongoClient();

            IMongoDatabase db = client.GetDatabase("tags");
            var collection = db.GetCollection<BsonDocument>("test");

            var document = new BsonDocument
            {
              {"firstname", BsonValue.Create("Peter")},
              {"lastname", new BsonString("Mbanugo")},
              { "subjects", new BsonArray(new[] {"English", "Mathematics", "Physics"}) },
              { "class", "JSS 3" },
              { "age", 23 }
            };

            await collection.InsertOneAsync(document);
        }
        //static void Main(string[] args)
        //{
        //    MainAsync().Wait();

            
        //    Console.WriteLine("Hello World!");
        //}

    }
}
