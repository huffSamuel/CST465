using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CST465Project
{
    public class ShortAnswerQuestion : TestQuestion
    {
        [Required]
        [StringLength(100)]
        public string Answer { get; set; }
    }
}