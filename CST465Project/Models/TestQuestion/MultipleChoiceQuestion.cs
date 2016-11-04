using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CST465Project
{
    public class MultipleChoiceQuestion : TestQuestion
    {
        [Required]
        public string Answer { get; set; }
    }
}