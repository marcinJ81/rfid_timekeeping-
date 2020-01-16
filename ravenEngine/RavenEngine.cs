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
}
