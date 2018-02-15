using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebPage.Models
{
    public class ContactModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType("Email")]
        public string  Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}