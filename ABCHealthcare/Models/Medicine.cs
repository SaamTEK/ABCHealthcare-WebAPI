using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABCHealthcare.Models
{
    public class Medicine
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Image { get; set; }

        public string Seller { get; set; }

        public bool Availability { get; set; }

        public int CategoryId { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public virtual Category Category { get; set; }
    }
}