using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST465Project
{
    public class TestQuestion
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public virtual string Answer { get; set; }
    }
}
