using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Messages
    {
        [Key]
        public int MessageId { get; set; }
        public string Topic { get; set; }
        public string Speaker { get; set; }
        public string Uri { get; set; }
    }
}