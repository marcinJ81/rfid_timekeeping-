using mongoEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTest.Models
{
    public class Tag_model
    {
        private IMongoInreface<DB_repository.Tag> imongointerface;
        public Tag_model()
        {
            this.imongointerface = new MongoInterfaceClass<DB_repository.Tag>();
        }
        public List<DB_repository.Tag> GetAllTags()
        {
            var documents2 = imongointerface.GetAllDocumentsFromCollection();
            return documents2;
        }
        public List<TagForView> GetTagForView()
        {
            var documents2 = imongointerface.GetAllDocumentsFromCollection();
            var result = documents2.Select(x => new TagForView
            {
                ID = x.Id,
                Tag_id = x.Tag_id,
                Tag_label = x.Tag_label,
                Tag_DateTime = x.Tag_time.ToString()
            }).ToList();
            return result;
        }
    }
    public class TagForView
    {
        public string ID { get; set; }
        public string Tag_id { get; set; }
        public string Tag_label { get; set; }
        public string Tag_DateTime { get; set; }
    }
}