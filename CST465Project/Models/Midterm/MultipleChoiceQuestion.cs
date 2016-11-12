using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST465Project
{
    public class MultipleChoiceQuestion : TestQuestion
    {
        [Required]
        override public string Answer { get { return base.Answer; } set { base.Answer = value; } }
        public List<string> Choices { get; set; }
    }
}