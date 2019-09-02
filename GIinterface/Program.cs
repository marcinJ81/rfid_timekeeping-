using DB_repository;
using MongoDB.Driver;
using mongoEngine;
using System;

namespace GIinterface
{
    class Program
    {
        private static IMongoConnection imongoCon { get; set; }
        private static ITag_Services<DB_repository.Tag> itag { get; set; }
        public Program()
        {
            imongoCon = new MongoConnection();
            itag = new Tag_services();
        }
        static void Main(string[] args)
        {
            string collectionName = "tags";
            var database = imongoCon.setConnocetion().GetDatabase("mydb");
            var collection = database.GetCollection<DB_repository.Tag>(collectionName);

            var model = itag.getEmptyModel();
            collection.InsertOneAsync(model); 
            Console.WriteLine("Hello World!");
        }
    }
}
