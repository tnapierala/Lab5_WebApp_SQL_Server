using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Sql_Server.Data.Models
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
    
}
