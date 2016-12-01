using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST465Project
{
    public class Product : IDataEntity
    {
        public int ID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string ProductDescription { get; set; }
        public float Price { get; set; }
        public string ImageFileName { get; set; }
        public string ImageContentType { get; set; }
        public byte[] ProductImage { get; set; }
        public int Quantity { get; set; }
        
    }
}