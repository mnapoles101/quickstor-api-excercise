using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quickstore_API.Requests
{
    public class UserAddRequest
    {

        [Required]
        [Range(1, 3)]
        public int RoleId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 2)]
        public string ZipCode { get; set; }

      
        
    }
}