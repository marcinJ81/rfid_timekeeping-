using Raven.Client;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;

namespace ravenEngine
{
    /// <summary>
    /// https://ravendb.net/features/clients/csharp
    /// </summary>
    public static class DBConnetTest
    {
        private static readonly Lazy<IDocumentStore> LazyStore =
         new Lazy<IDocumentStore>(() =>
         {
             var store = new DocumentStore
             {
                 Urls = new[] { "http://localhost:8080" },
                 Database = "ravenTest"
             };

             return store.Initialize();
         });

        public static IDocumentStore Store => LazyStore.Value;
    }
    public static class DBConnect2
    {
        public static IDocumentStore idb =
            new DocumentStore()
            {
                Database = "test3",
                Urls = new[] { "http://localhost:8080" }
            }.Initialize();
    }

    
    public class RavenTest
    {
        public void InsertOne()
        {
            using (IDocumentSession session = DBConnetTest.Store.OpenSession())
            {
                var category = new Category
                {
                    Name = "Tags",
                    id = 1
                };

                session.Store(category);

                var product = new Product
                {
                    Name = "Laptop 2000",
                    category_id = category
                };

                session.Store(product);
                session.SaveChanges();
            }
        }
        public string InsertSpecificDocument()
        {
            using (IDocumentSession session = DBConnect2.idb.OpenSession())
            {
                SProduct sProduct = new SProduct()
                {
                    Id = string.Empty, // if empty db generate GUID, case sensitivity
                    Number = 1,
                    Name = "Muscle Car",
                    RegisterDate = DateTime.Now
                };
                session.Store(sProduct);
                session.SaveChanges();
                var guid = session.Advanced.GetDocumentId(sProduct);
                return guid;
            }
        }

    }
}
