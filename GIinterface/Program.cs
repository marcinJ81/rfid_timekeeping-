using mongoEngine;
using System;

namespace GIinterface
{
    class Program
    {
        private IMongoConnection imongoCon { get; set; }

        public Program()
        {
            this.imongoCon = new MongoConnection();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
