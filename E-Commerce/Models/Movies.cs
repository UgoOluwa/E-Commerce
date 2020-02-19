using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Uri { get; set; }
    }
}