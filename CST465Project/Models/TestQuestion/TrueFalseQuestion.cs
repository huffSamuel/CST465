using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CST465Project
{
    public class TrueFalseQuestion : TestQuestion
    {
        [Required]
        [RegularExpression("^(?:tru|fals)e$")]
        public string Answer { get; set; }
    }
}