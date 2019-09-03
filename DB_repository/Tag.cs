using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DB_repository
{
    public class Tag
    {
        [BsonId]
        [BsonElement("id")]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("tag_id")]
        public string Tag_id { get; set; }
      
        [BsonElement("tag_label")]
        public string Tag_label { get; set; }

    }
}
