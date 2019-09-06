## Application for measuring time with RFID device
#### Simple description
- RFID device for measuring time;
- tag standard Unique;
- database MongoDB;
- partition by responsibility (?);

This good place for learn english.

####Description.
Simple class mapped in to database

####Javascript　
```javascript
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
```
Interface for class Tag

####Javascript　
```javascript
public interface ITag_Services<T> where T : class
    {
        List<T> getListResult();
        T getData();
        T getEmptyModel();
        void addData(T model);
    }
```

Interface with constraints on type parameters

###Blockquotes

> where T : class - The type argument must be a reference type. Where T is any class.

###Links

[Links](https://docs.microsoft.com/pl-pl/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters)

Fulfillment of the contract in class Tag_services

####Inline code

` public class Tag_services : ITag_Services<Tag>, IDisposable`



