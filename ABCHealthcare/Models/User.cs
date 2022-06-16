using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ABCHealthcare.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Roles { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Address { get; set; }

    }
}