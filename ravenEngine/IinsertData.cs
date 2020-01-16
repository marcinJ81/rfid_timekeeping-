using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ravenEngine
{
    public interface IInsertData
    {
        string InsertOne();
        string insertSpecificDocument();
        List<Product> getAllProducts();
    }
    public class InsertData : IInsertData
    {
        public List<Product> getAllProducts()
        {
            using (IDocumentSession session = DBConnect2.idb.OpenSession())
            {

                List<Product> result = session.
                    Query<Product>().ToList();
                return result;
            }
        }

        public string InsertOne()
        {
            using (IDocumentSession session = DBConnect2.idb.OpenSession())// DBConnetTest.Store.OpenSession())
            {
                var category = new Category
                {
                    Name = "Car",
                    Id = "Category/1"
                };

                session.Store(category);

                var product = new Product
                {
                    Name = "Fiat",
                    category = category,
                    Id = "Product/1"
                };
                session.Store(product);
                session.SaveChanges();
                string result = session.Advanced.GetDocumentId(product);
                return result;
            }
        }

        public string insertSpecificDocument()
        {
            using (IDocumentSession session = DBConnect2.idb.OpenSession())// DBConnetTest.Store.OpenSession())
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
