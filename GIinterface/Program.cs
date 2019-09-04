﻿using DB_repository;
using MongoDB.Bson;
using MongoDB.Driver;
using mongoEngine;
using System;
using System.Threading.Tasks;

namespace GIinterface
{
    class Program
    {
        private static IMongoInreface<DB_repository.Tag> imongointerface { get; set; }
        private static ITag_Services<DB_repository.Tag> itag { get; set; }

        static void Main(string[] args)
        {
            IConnectMongoClient imongoCon = new ConnectMongoClient();
            imongointerface = new MongoInterfaceClass<DB_repository.Tag>();
            IGeneratorId igenId = new GenerateId();
            itag = new Tag_services();
            DB_repository.Tag tag = new DB_repository.Tag()
            {
                Id = Guid.NewGuid(),
                Tag_id = igenId.generateTagId(),
                Tag_label = igenId.generateLabel(),
                Tag_time = DateTime.Now.ToUniversalTime() //MongoDB stores all DateTimes in UTC
            };

             itag.addData(tag);
            imongointerface.InsertOne(itag.getData(), "test","tags");
           
             Console.WriteLine("Hello World!");
        }

    }
}
