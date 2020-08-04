using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quickstore_API.Models
{
    public class UserToken
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public int TokenType { get; set; }

        public ICollection<User> User { get; set; }
    }
}