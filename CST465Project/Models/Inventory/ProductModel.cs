using System;
using System.Drawing;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CST465Project
{
    public class ProductModel
    {
        [HiddenInput(DisplayValue =false)]
        public int ID { get; set; }
        
        [Required]
        [Display(Name ="Product Code")]
        [MaxLength(100)]
        public string ProductCode { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }
        public HttpPostedFileWrapper ProductImage { get; set; }
        public SelectList Categories { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}