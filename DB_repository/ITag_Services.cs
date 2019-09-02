using System;
using System.Collections.Generic;
using System.Text;

namespace DB_repository
{
   public interface ITag_Services<T> where T : class
    {
        List<T> getListResult();
        T getData();
        void addData(T model);
        T getEmptyModel();
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
            this.model.Id = model.Id;
            this.model.Tag_id = model.Tag_id;
            this.model.Tag_label = model.Tag_label;
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
                Id = Guid.NewGuid(),
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
