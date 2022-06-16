using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABCHealthcare.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}