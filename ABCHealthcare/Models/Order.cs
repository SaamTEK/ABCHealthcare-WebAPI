using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABCHealthcare.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int Qty { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}