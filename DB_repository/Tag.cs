using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DB_repository
{
    public class Tag
    {
        [BsonId]
        [BsonElement("id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("tag_id")]
        public string Tag_id { get; set; }
      
        [BsonElement("tag_label")]
        public string Tag_label { get; set; }

        [BsonElement("tag_time")]
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Tag_time { get; set; }


    }
}
