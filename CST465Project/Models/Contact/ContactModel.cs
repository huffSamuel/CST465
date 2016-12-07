using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CST465Project
{
    public class ContactModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name="Phone Number")]
        [RegularExpression(@"(\(\d{3}\)|\d{3}\-)\d{3}\-\d{4}", ErrorMessage ="Phone number must match XXX-XXX-XXXX")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}