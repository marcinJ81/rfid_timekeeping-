using System;
using System.Collections.Generic;
using System.Text;

namespace ravenEngine
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Category category { get; set; }
    }
    public class Category
    {
        public string Name { get; set; }
        public string Id { get; set; }

    }
    public class SProduct
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }

    }
}
