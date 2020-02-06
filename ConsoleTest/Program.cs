using DB_repository;
using MongoDB.Driver;
using mongoEngine;
using System;
using System.Threading;

namespace ConsoleTest
{
    public class ThreadSmple
    {
        private static IMongoInreface<DB_repository.Tag> imongointerface { get; set; }
        private static ITag_Services<DB_repository.Tag> itag { get; set; }
        public DB_repository.Tag addingTag { get; private set; }
               
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
            int caseSwitch = 0;
            while (caseSwitch != 4)
            {
                //Console.Clear();
                Console.WriteLine("2: Wyświetl cala baze");
                Console.WriteLine("podaj liczebe");
                caseSwitch = int.Parse(Console.ReadLine());
                switch (caseSwitch)
                {
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Opcja 2 - odczyt");
                        Thread th2 = new Thread(new ThreadStart(threadTest));
                        th2.Start();
                        th2.Join();
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
    }
}
