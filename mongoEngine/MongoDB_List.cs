using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mongoEngine
{
    public class MongoDBPArameters
    {
        public int id_db { get; set; }
        public string name { get; set; }
        public string collection_name { get; set; }
        public string base_name { get; set; }
    }
    public interface IMongo_List
    {
        void addElement(MongoDBPArameters dBparameters);
        MongoDBPArameters getSpecificParamters(string name);
    }
    public class MongoDB_List : IMongo_List
    {
        private List<MongoDBPArameters> listOfMongoDB { get; set; }
        public MongoDB_List()
        {
            this.listOfMongoDB = new List<MongoDBPArameters>();
        }
        public void addElement(MongoDBPArameters dBparameters)
        {
            this.listOfMongoDB.Add(new MongoDBPArameters
            {
                id_db = 1,
                name = "test_mongo",
                collection_name = "test",
                base_name = "tags",
            });
        }

        public MongoDBPArameters getSpecificParamters(string name)
        {
            if (this.listOfMongoDB.Any())
            {
                var result = this.listOfMongoDB.Where(x => x.base_name == name).First();
                return result;
            }
            else
            {
                MongoDBPArameters emptyList = new MongoDBPArameters()
                    {                      
                          id_db = 0,
                          name = "brak",
                          base_name = "",
                          collection_name =""
                    };
                return emptyList;
            }
        }
    }
}
