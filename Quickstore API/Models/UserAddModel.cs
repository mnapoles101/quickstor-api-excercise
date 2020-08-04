using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quickstore_API.Models
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var ctx = new User())
            {
                var stud = new User() { StudentName = "Bill" };

                ctx.Students.Add(stud);
                ctx.SaveChanges();
            }
        }
    }
}