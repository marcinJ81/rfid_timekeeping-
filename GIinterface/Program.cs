using DB_repository;
using MongoDB.Bson;
using MongoDB.Driver;
using mongoEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GIinterface
{
   public class ThreadSmple
    {
        private static IMongoInreface<DB_repository.Tag> imongointerface { get; set; }
        private static ITag_Services<DB_repository.Tag> itag { get; set; }
        public DB_repository.Tag addingTag { get; private set; }
        public void threadAdd(object tag)
        {
            IMongo_List ilistDB = new MongoDB_List();
            IConnectMongoClient imongoCon = new ConnectMongoClient();
            imongointerface = new MongoInterfaceClass<DB_repository.Tag>();
            itag = new Tag_services();
            itag.addData((DB_repository.Tag)tag);
            imongointerface.InsertOne(itag.getData());
            addingTag = itag.getData();
        }

        public object createTag()
        {
            IGeneratorId igenId = new GenerateId();
            DB_repository.Tag tag = new DB_repository.Tag()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Tag_id = igenId.generateTagId(),
                Tag_label = igenId.generateLabel(),
                Tag_time = DateTime.Now.ToUniversalTime()
            };
            return tag;
        }
    }
    class Program
    {
        private static IMongoInreface<DB_repository.Tag> imongointerface { get; set; }
        private static ITag_Services<DB_repository.Tag> itag { get; set; }
        private static readonly object m_oPadlock = new object();
        static void Main(string[] args)
        {
            imongointerface = new MongoInterfaceClass<DB_repository.Tag>();
            Thread thMain = new Thread(new ThreadStart(menu));
            thMain.Start();
            thMain.Join();
        }

        public static void menu()
        {
            ThreadSmple threadSimple = new ThreadSmple();
            object newTag = threadSimple.createTag();

            int caseSwitch = 0;
            while (caseSwitch != 4)
            {
                //Console.Clear();
                Console.WriteLine("1: Dodaj do bazy");
                Console.WriteLine("2: Wyświetl cala baze");
                Console.WriteLine("3: Wyświetl ostatni dodany dokument");
                Console.WriteLine("podaj liczebe");
                caseSwitch = int.Parse(Console.ReadLine());
                switch (caseSwitch)
                {
                    case 1:
                        Console.WriteLine("Opcja 1, zapis");
                        Thread th1 = new Thread(new ParameterizedThreadStart(threadSimple.threadAdd));
                        th1.Start(newTag);
                        th1.Join();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Opcja 2 - odczyt");
                        Thread th2 = new Thread(new ThreadStart(threadTest));
                        th2.Start();
                        th2.Join();
                        break;
                    case 3:
                        Console.WriteLine("Pokaż ostatnio dodany tag");
                        Thread th3 = new Thread(new ParameterizedThreadStart(getElement));
                        th3.Start(threadSimple.addingTag);
                        th3.Join();
                        break;
                    case 4:
                        Console.WriteLine("Koniec");
                        break;
                }
            }
        }
        static void threadTest()
        {
                var documents2 = imongointerface.GetAllDocumentsFromCollection();

                foreach (var i in documents2)
                {

                    Console.WriteLine(i.Id + " " + i.Tag_id + " " + i.Tag_label + " " + i.Tag_time.ToLongTimeString());
                }
        }

        static void getElement(object tag)
        {
            DB_repository.Tag tagFilter = (DB_repository.Tag)tag;
            FilterDefinition<DB_repository.Tag> filter = Builders<DB_repository.Tag>.Filter.Eq("tag_label", tagFilter.Tag_label);
            var result = imongointerface.GEtSpecificDocument(filter);
            Console.WriteLine(result.Id + " " + result.Tag_id + " " + result.Tag_label + " " + result.Tag_time.ToLongTimeString());
        }


    }
}
