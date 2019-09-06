## Application for measuring time with RFID device
#### Simple description
- RFID device for measuring time;
- tag standard Unique;
- database MongoDB;
- .net core  console UI;
- partition by responsibility (?);

This good place for learn english ;-)

### Description.
At this moment I have for project in solution:
- DB_repository,
- mongoEngine,
- UI_interface - project for test other projects
- NUnitTestProject
For now all methods in this project are synchronous. In the future they will be asynchronous.

### Code.
Simple class mapped in to database

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
###### Interface for class Tag

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

- where T : class - The type argument must be a reference type. Where T is any class.

[MSDN - Constraint on type parameters](https://docs.microsoft.com/pl-pl/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters)

###### Fulfillment of the contract in class Tag_services

` public class Tag_services : ITag_Services<Tag>, IDisposable`

##### Main Interface (contract) in project mongoEngine

```javascript
	public interface IMongoInreface<T> where T : class
    {
        void InsertOne(T model);
        void UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> source);
        List<T> GetAllDocumentsFromCollection();
        T GEtSpecificDocument(FilterDefinition<T> filter);
        void DeleteOne(FilterDefinition<T> filter);
    }
```
###### Fulfillment of the contract in class Tag_services

` public class MongoInterfaceClass<T> : IMongoInreface<T> where T : class, new() `

- where T : class, new() - Type argument must be a reference type and must have constructor




