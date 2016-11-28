using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CST465Project
{
    public class CategoryModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        [MaxLength(200)]
        public string CategoryName { get; set; }
    }
}