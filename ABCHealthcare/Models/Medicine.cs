using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABCHealthcare.Models
{
    public class Medicine
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]

        public double Price { get; set; }

        public string Image { get; set; }

        [Required]

        public string Seller { get; set; }

        [Required]

        public bool Availability { get; set; }

        [Required]

        public int CategoryId { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public virtual Category Category { get; set; }
    }
}