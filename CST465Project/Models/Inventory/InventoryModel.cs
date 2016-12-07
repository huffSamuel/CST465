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
    public class InventoryModel
    {
        public List<Product> products { get; set; }
        public SelectList categories { get; set; }
    }
}