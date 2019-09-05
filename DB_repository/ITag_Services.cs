using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB_repository
{
   public interface ITag_Services<T> where T : class
    {
        List<T> getListResult();
        T getData();
        T getEmptyModel();
        void addData(T model);
    }

    public class Tag_services : ITag_Services<Tag>, IDisposable
    {
        private Tag model { get; set; }
        public Tag_services()
        {
            this.model = new Tag();
        }
        public void addData(Tag model)
        {
            this.model.Id = ObjectId.GenerateNewId().ToString();
            this.model.Tag_id = model.Tag_id;
            this.model.Tag_label = model.Tag_label;
            this.model.Tag_time = model.Tag_time;
        }

        public Tag getData()
        {
            if (this.model != null)
                return this.model;
            else
                return getEmptyModel();
        }

        public Tag getEmptyModel()
        {
            Tag tag = new Tag
            {
                Id = "1",
                Tag_id = "brak",
                Tag_label = "brak"
            };
            return tag;
        }

        public List<Tag> getListResult()
        {
            List<Tag> result = new List<Tag>();
            result.Add(getEmptyModel());
            return result;
        }

        public void Dispose()
        {
            this.model = null;
        }

    }
}
