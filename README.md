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

###  mongoEngine project.
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

**Example - add document to collection**
```csharp
Class Program
{
	private static IMongoInreface<DB_repository.Tag> imongointerface { get; set; }
	private static ITag_Services<DB_repository.Tag> itag { get; set; }

	static void Main(string[] args)
    {
            IMongo_List ilistDB = new MongoDB_List();

            IConnectMongoClient imongoCon = new ConnectMongoClient();
            imongointerface = new MongoInterfaceClass<DB_repository.Tag>();
            IGeneratorId igenId = new GenerateId();
            itag = new Tag_services();
            DB_repository.Tag tag = new DB_repository.Tag()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Tag_id = igenId.generateTagId(),
                Tag_label = igenId.generateLabel(),
                Tag_time = DateTime.Now.ToUniversalTime()
            };

            itag.addData(tag);
            imongointerface.InsertOne(itag.getData());
     }
}
```
Description to code

    private static IMongoInreface<DB_repository.Tag> imongointerface { get; set; }
	private static ITag_Services<DB_repository.Tag> itag { get; set; }

Interfaces declaration
- imongointerface - interface with all methods to be use in database,
- itag -  methods to be use in class Tag.

     IMongo_List ilistDB = new MongoDB_List();

ilist - List of parameters to conect to MongoDB

### RFID_interface1 project.
This project have methods to connect specified RFID device. In application I have two different RFID devices.
1.  [Unique transponder reader](http://www.mikrokontrola.pl/index.php) -  Library added from producent topto.dll, device operation via threads. Now I don't have this devices but I have working and checked code,
2. [RFID-USB-DESK reade](https://botland.com.pl/en/inveo-smart-controllers/9123-inveo-rfid-usb-desk-reader-unique-125khz-5903351240840.html) - device operation via interrupts.

Description for  point 1.

Main interface in this this project is ISerialPortAndTransponderDevice (Unique transponder reader). We use to: 
- portNames() - list of serial ports,
- getAdresForPort(string portName) - get adres for serial port,
- bool initializeDevice(string portName) - initialize transponder
- bool ReadTagId(out long) - read card id from device,
- Transponder deviceHandler (propertis).

**Attention**
In the future I want to add thread support. 

### RavenEngine project.
RavenDB NoSQL document database.

**Set connect to DB**

```csharp
public static class DBConnect2
    {
        public static IDocumentStore idb =
            new DocumentStore()
            {
                Database = "test3",
                Urls = new[] { "http://localhost:8080" }
            }.Initialize();
    }
```
Or, example from documentation RavenDB
```csharp
public static class DBConnetTest
    {
        private static readonly Lazy<IDocumentStore> LazyStore =
         new Lazy<IDocumentStore>(() =>
         {
             var store = new DocumentStore
             {
                 Urls = new[] { "http://localhost:8080" },
                 Database = "test2"
             };

             return store.Initialize();
         });

        public static IDocumentStore Store => LazyStore.Value;
    }
```







