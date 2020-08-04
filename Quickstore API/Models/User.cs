using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;

namespace Quickstore_API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string ZipCode { get; set; }
        public DateTime DateCreated { get; set; }
        
    }
}